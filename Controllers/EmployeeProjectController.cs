using Microsoft.AspNetCore.Mvc;
using Silver_Pirates.Services;
using Silver_Pirates_API;

namespace Silver_Pirates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectController : ControllerBase
    {
        private IEmployeeProject<EmployeeProject> _employeeProject;
        public EmployeeProjectController(IEmployeeProject<EmployeeProject> employeeProject)
        {
            this._employeeProject = employeeProject;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeProject.GetAll());
        }
    }
}
