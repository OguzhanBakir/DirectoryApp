using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Web.Models.Report
{
    public class ReportResult
    {
        public Guid ReportResultId { get; set; }
        public DateTime RequestDateTime { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string ReportStatus { get; set; }
        public string FileLocation { get; set; }
    }
}
