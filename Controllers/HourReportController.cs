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
        public IActionResult GetHourReport(int id) {
            var res = _hourReport.GetSingle(id);
            if (res != null) {
                return Ok(res);
            }

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

        [HttpGet("/EmployeeHourReport/id{id:int}/week{week:int}")]
        public IActionResult GetAllHourReportsFromEmployeeByWeek(int id, int week)
        {
            var res = _hourReport.GetAllHourReportsFromEmployeeByWeek(id, week);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound($"Employee with {id} was not found...");
        }

        [HttpPut("/UpdateHourReport/id{id:int}/{name}")]
        public IActionResult UpdateHourReport(int id, int employeeId, DateTime date) {

            var res = _hourReport.GetSingle(id);
            if (res != null) {
                HourReport updated = new HourReport {
                    ReportId = id,
                    EmployeeId = employeeId,
                    DateWorked = date
                };
                _hourReport.Update(updated);
                return Ok(updated);
            }
            return NotFound($"Hour report with Id : {id} was not found...");

        }

        [HttpPost]
        public IActionResult NewHourReport(HourReport hourReport) {

            try {

                if (hourReport == null)
                    return BadRequest();

                var newHourReport = _hourReport.Add(hourReport);
                //Gets the name of the employee ás well as returns the id
                return CreatedAtAction(nameof(GetHourReport), new { Id = hourReport.ReportId }, newHourReport);

            } catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add hour report...");
            }

        }

        [HttpDelete("/DeleteHourReport/id{id:int}")]
        public IActionResult DeleteProject(int id) {

            var res = _hourReport.GetSingle(id);
            if (res != null) {
                _hourReport.Delete(id);
                return Ok(res);
            }
            return NotFound($"Hour report with Id : {id} was not found...");

        }

    }
}
