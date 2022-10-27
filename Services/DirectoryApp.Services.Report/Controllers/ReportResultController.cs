using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DirectoryApp.Shared.ControllerBases;
using DirectoryApp.BLL.Abstract;

namespace DirectoryApp.Services.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ReportResultController : CustomBaseController
    {

        private readonly IReportResultService _reportResultService;

        public ReportResultController(IReportResultService reportResultService)
        {
            _reportResultService = reportResultService;
        }


        [HttpGet]
        [Route("GetAllReport")]
        public async Task<IActionResult> GetAllReport()
        {
            var reportResult = await _reportResultService.GetAllAsync();

            return CreateActionResultInstance(reportResult);
        }



        [HttpPost]
        [Route("GenerateReport")]
        public async Task<IActionResult> GenerateReport()
        {
            var response = await _reportResultService.GenerateReportRequest();

            return CreateActionResultInstance(response);
        }




    }
}
