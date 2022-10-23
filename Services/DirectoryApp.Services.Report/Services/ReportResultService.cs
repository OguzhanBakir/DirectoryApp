using DirectoryApp.Services.Report.Data;
using DirectoryApp.Services.Report.Models;
using DirectoryApp.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.Report.Services
{
    public class ReportResultService:IReportResultService
    {
        private readonly ReportContext _dbContext;

        private readonly RabbitMQPublisher _rabbitMQPublisher;


        public ReportResultService(ReportContext dbContext, RabbitMQPublisher rabbitMQPublisher)
        {
            _dbContext = dbContext;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        public async Task<Response<List<ReportResult>>> GetAllAsync()
        {
            var reports = await _dbContext.Report.ToListAsync();

            return Response<List<ReportResult>>.Success(reports, 200);
        }


        public async Task<Response<ReportResult>> GenerateReportRequest()
        {

            Guid reportResId = new Guid();

            ReportResult repResultAdd = new ReportResult()
            {
                ReportResultId=reportResId,
                ReportStatus="Hazırlanıyor",
                RequestDateTime=DateTime.Now
            };


            await _dbContext.AddAsync(repResultAdd);

            var saveStatus = await _dbContext.SaveChangesAsync();


            if (saveStatus>0)
            {

               
                _rabbitMQPublisher.Publish(new Shared.CreateExcelMessage() { ReportResultId = repResultAdd.ReportResultId });
                return Response<ReportResult>.Success(repResultAdd, 200);
            }


            return Response<ReportResult>.Fail("An error occurred while adding", 404);



        }


    }
}
