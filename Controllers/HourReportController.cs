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

        [HttpGet("HourReportId")]
        public IActionResult GetEmployee(int id) {
            var res = _hourReport.GetSingle(id);
            if (res != null)
                return Ok(res);

            return NotFound($"Hour Report with {id} was not found...");
        }

        [HttpGet("/EmployeeHourReport/id{id:int}")]
        public IActionResult GetAllHourReportsById(int id)
        {
            var res = _hourReport.GetAllHourReportsFromEmployee(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound($"Employee with {id} was not found...");
        }
    }
}
