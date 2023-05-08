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

        [HttpGet("/GetEmployee/id{id:int}")]
        public IActionResult GetEmployee(int id) {

            var res = _employee.GetSingle(id);
            if (res != null) {
                return Ok(res);
            }
            return NotFound($"Employee with Id : {id} was not found...");

        }

        //WIll probably be changed in the future
        // since it only changes the name atm
        [HttpPut("/UpdateNameOfEmployee/id{id:int}/{name}")]
        public IActionResult UpdateEmployee(int id, string name) {

            var res = _employee.GetSingle(id);
            if (res != null) {
                Employee updated = new Employee {
                    EmployeeId = id,
                    Name = name
                };
                _employee.Update(updated);
                return Ok(updated); 
            }
            return NotFound($"Employee with Id : {id} was not found...");

        }

        [HttpPost]
        public IActionResult NewEmployee(int id, string name) {

            try {

                Employee newEmployee = new Employee() {
                    EmployeeId = id,
                    Name = name
                };
                return Ok(newEmployee);

            } catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add employee...");
            }

        }

        [HttpDelete("/DeleteEmployee/id{id:int}")]
        public IActionResult DeleteEmployee(int id) {

            var res = _employee.GetSingle(id);
            if (res != null) {
                _employee.Delete(id);
                return Ok(res);
            }
            return NotFound($"Employee with Id : {id} was not found...");

        }


    }
}
