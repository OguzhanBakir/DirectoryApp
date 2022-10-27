using DirectoryApp.BLL.Abstract;
using DirectoryApp.Core.Entities;
using DirectoryApp.Core.Utilities.RabbitMQ;
using DirectoryApp.DAL.Abstract;
using DirectoryApp.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectoryApp.BLL.Concrete
{
    public class ReportResultManager : IReportResultService
    {
        private readonly IReportResultDAL _reportResultDal;
        private readonly RabbitMQPublisher _rabbitMQPublisher;
        public ReportResultManager(IReportResultDAL reportResultDal, RabbitMQPublisher rabbitMQPublisher)
        {
            _reportResultDal = reportResultDal;
            _rabbitMQPublisher = rabbitMQPublisher;

        }
        public async Task<Response<ReportResult>> GenerateReportRequest()
        {
            var result = await _reportResultDal.GenerateReportRequest();
            if (result!=null)
            {
                _rabbitMQPublisher.Publish(new CreateExcelMessage() { ReportResultId = result.ReportResultId });
                return Response<ReportResult>.Success(result, 200);

            }
            else
            {
                return Response<ReportResult>.Fail("An error occured while adding", 404);
            }

        }

        public async Task<Response<List<ReportResult>>> GetAllAsync()
        {
            var result = await _reportResultDal.GetAllAsync();
            return Response<List<ReportResult>>.Success(result, 200);

        }


    }
}
