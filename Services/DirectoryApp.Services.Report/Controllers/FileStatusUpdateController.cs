using DirectoryApp.Services.Report.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.Report.Controllers
{
    
    [ApiController]
    public class FileStatusUpdateController : ControllerBase
    {
        private readonly ReportContext _dbContext;

        public FileStatusUpdateController(ReportContext dbContext)
        {
            _dbContext = dbContext;
            
        }


        [Route("FileStatusUpdate")]
        [HttpPost]
        public async Task<IActionResult> StatusUpdate(Guid reportResultId,string fileName)
        {
           


            var reportFile = await _dbContext.Report.SingleOrDefaultAsync(x => x.ReportResultId == reportResultId);




            if (reportFile != null)
            {

                reportFile.CreationDateTime = DateTime.Now;
                reportFile.FileLocation = fileName;
                reportFile.ReportStatus = "Tamamlandı";

                await _dbContext.SaveChangesAsync();

                //Zaman kalırsa SignalR

             




            }


            return Ok();

        }
    }
}
