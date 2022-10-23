using DirectoryApp.Services.Report.Models;
using DirectoryApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.Report.Services
{
    public interface IReportResultService
    {
        Task<Response<List<ReportResult>>> GetAllAsync();

        Task<Response<ReportResult>> GenerateReportRequest();
    }
}
