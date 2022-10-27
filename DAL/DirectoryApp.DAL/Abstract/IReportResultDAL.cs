using DirectoryApp.Core.Entities;
using DirectoryApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.DAL.Abstract
{
    public interface IReportResultDAL
    {
        Task<List<ReportResult>> GetAllAsync();

        Task<ReportResult> GenerateReportRequest();
    }
}
