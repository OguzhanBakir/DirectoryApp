using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.CrudOperations.Models
{
    public class ReportResult
    {
        

        public string ReportResultId { get; set; }
        public DateTime RequestDateTime { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string ReportStatus { get; set; }

        public string FileLocation { get; set; }

    }
}
