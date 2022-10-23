
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryApp.Services.Web.Controllers
{

    [ApiController]
    public class FileUploadController : ControllerBase
    {
       


        [Route("FileUpload")]
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, Guid reportResultId,string fileName)
        {
            if (file is not { Length: > 0 }) return BadRequest();


            
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/reports", fileName);



            using FileStream stream = new(path, FileMode.Create);

            await file.CopyToAsync(stream);



            return Ok();
        }
    }
}
