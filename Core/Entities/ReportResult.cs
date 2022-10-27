using System;

namespace DirectoryApp.Core.Entities
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
