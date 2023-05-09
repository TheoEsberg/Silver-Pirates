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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _hourReport.GetAll());
        }

        [HttpGet("HourReportId")]
        public async Task<IActionResult> GetHourReport(int id) {
            var res = await _hourReport.GetSingle(id);
            if (res != null) {
                return Ok(res);
            }

            return NotFound($"Hour Report with {id} was not found...");
        }

        [HttpGet("/EmployeeHourReport/id{id:int}")]
        public async Task<IActionResult> GetAllHourReportsById(int id)
        {
            var res = await _hourReport.GetAllHourReportsFromEmployee(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound($"Employee with {id} was not found...");
        }

        [HttpGet("/EmployeeHourReport/id{id:int}/week{week:int}")]
        public async Task<IActionResult> GetAllHourReportsFromEmployeeByWeek(int id, int week)
        {
            var res = await _hourReport.GetAllHourReportsFromEmployeeByWeek(id, week);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound($"Employee with {id} was not found...");
        }

        [HttpPut("/UpdateHourReport/id{id:int}/{name}")]
        public async Task<IActionResult> UpdateHourReport(int id, int employeeId, DateTime date) {

            var res = await _hourReport.GetSingle(id);
            if (res != null) {
                HourReport updated = new HourReport {
                    ReportId = id,
                    EmployeeId = employeeId,
                    DateWorked = date
                };
                await _hourReport.Update(updated);
                return Ok(updated);
            }
            return NotFound($"Hour report with Id : {id} was not found...");

        }

        [HttpPost]
        public async Task<IActionResult> NewHourReport(HourReport hourReport) {

            try {
                if (hourReport == null)
                    return BadRequest();

                var newHourReport = await _hourReport.Add(hourReport);
                //Gets the name of the employee ás well as returns the id
                return CreatedAtAction(nameof(GetHourReport), new { Id = hourReport.ReportId }, newHourReport);

            } catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add hour report...");
            }

        }

        [HttpDelete("/DeleteHourReport/id{id:int}")]
        public async Task<IActionResult> DeleteProject(int id) {

            var res = await _hourReport.GetSingle(id);
            if (res != null) {
                await _hourReport.Delete(id);
                return Ok(res);
            }
            return NotFound($"Hour report with Id : {id} was not found...");

        }

    }
}
