using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Core.Utilities.RabbitMQ
{
    public class CreateExcelMessage
    {
        public Guid ReportResultId { get; set; }
    }
}
