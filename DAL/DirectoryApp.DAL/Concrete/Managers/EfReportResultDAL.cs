using DirectoryApp.DAL.Abstract;
using DirectoryApp.DAL.Concrete.EntityFramework.Context;
using DirectoryApp.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DirectoryApp.Shared;
using DirectoryApp.Core.Entities;

namespace DirectoryApp.DAL.Concrete.Managers
{
    public class EfReportResultDAL : IReportResultDAL
    {
        private readonly ReportContext _dbContext;



        public EfReportResultDAL(ReportContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ReportResult>> GetAllAsync()
        {
            return await _dbContext.Report.ToListAsync();

        }


        public async Task<ReportResult> GenerateReportRequest()
        {

            Guid reportResId = new Guid();

            ReportResult repResultAdd = new ReportResult()
            {
                ReportResultId = reportResId,
                ReportStatus = "Hazırlanıyor",
                RequestDateTime = DateTime.Now
            };


            await _dbContext.Report.AddAsync(repResultAdd);

            var saveStatus = await _dbContext.SaveChangesAsync();


            if (saveStatus > 0)
            {

                return repResultAdd;
                
            }

            return null;



        }


    }
}
