using Microsoft.AspNetCore.Mvc;
using Silver_Pirates.Migrations;
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

        // Get all HourReports
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _hourReport.GetAll());
        }

        // Get a HourReport by HourReportId
        [HttpGet("HourReportId")]
        public async Task<IActionResult> GetHourReport(int id) 
        {
            var res = await _hourReport.GetSingle(id);
            if (res != null) 
            {
                return Ok(res);
            }
            return NotFound($"Hour Report with {id} was not found...");
        }

        // Get all HourReports connected to a Employee by EmployeeId
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

        // Get all Hours Worked at a specific week by EmployeeId
        [HttpGet("/EmployeeHourReport/id{id:int}/week{week:int}")]
        public async Task<IActionResult> GetAllHourReportsFromEmployeeByWeek(int id, int week)
        {
            var res = await _hourReport.GetAllHourReportsFromEmployeeByWeek(id, week);
            return Ok($"Employee with id = {id} has worked {res}h on week {week}.");
        }

        // Update a Hour Report by HourReport Id
        [HttpPut("/UpdateHourReport/id{id:int}/employeeId/date")]
        public async Task<IActionResult> UpdateHourReport(int id, int employeeId, DateTime date) 
        {
            var res = await _hourReport.GetSingle(id);
            if (res != null) 
            {
                HourReport updated = new HourReport 
                {
                    ReportId = id,
                    EmployeeId = employeeId,
                    DateWorked = date
                };
                await _hourReport.Update(updated);
                return Ok(updated);
            }
            return NotFound($"Hour report with Id : {id} was not found...");
        }

        // Add a new HourReport
        [HttpPost]
        public async Task<IActionResult> NewHourReport(double hoursWorked, int employeeId, DateTime startDate) 
        {
            try 
            {
                if (hoursWorked == 0) 
                {
                    return BadRequest();
                }
                    
                var newHourReport = await _hourReport.Add(hoursWorked, employeeId, startDate);
                return Ok(newHourReport);
            } 

            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add hour report...");
            }
        }

        // Delete an existing HourReport
        [HttpDelete("/DeleteHourReport/id{id:int}")]
        public async Task<IActionResult> DeleteProject(int id) 
        {
            var res = await _hourReport.GetSingle(id);
            if (res != null) 
            {
                await _hourReport.Delete(id);
                return Ok(res);
            }
            return NotFound($"Hour report with Id : {id} was not found...");
        }
    }
}
