using DirectoryApp.Core.Entities;
using DirectoryApp.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectoryApp.BLL.Abstract
{
    public interface IReportResultService
    {
        Task<Response<List<ReportResult>>> GetAllAsync();
        Task<Response<ReportResult>> GenerateReportRequest();

    }
}
