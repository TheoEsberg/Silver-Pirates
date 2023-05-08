using Microsoft.AspNetCore.Mvc;
using Silver_Pirates.Services;
using Silver_Pirates_API;

namespace Silver_Pirates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployee<Employee> _employee;

        public EmployeeController(IEmployee<Employee> employee)
        {
            this._employee = employee;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employee.GetAll());
        }
    }
}
