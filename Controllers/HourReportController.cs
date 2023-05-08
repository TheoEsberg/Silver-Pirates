using Microsoft.AspNetCore.Mvc;
using Silver_Pirates.Services;
using Silver_Pirates_API;

namespace Silver_Pirates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HourReportController : ControllerBase
    {
        private IHourReport<HourReport> _hourReport;

        public HourReportController(IHourReport<HourReport> hourReport)
        {
            this._hourReport = hourReport;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_hourReport.GetAll());
        }
    }
}
