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
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employee.GetAll();
            return Ok(employees);
        }

        [HttpGet("/GetEmployee/id{id:int}")]
        public async Task<IActionResult> GetEmployee(int id) {

            var res = await _employee.GetSingle(id);
            if (res != null) {
                return Ok(res);
            }
            return NotFound($"Employee with Id : {id} was not found...");

        }

        //WIll probably be changed in the future
        // since it only changes the name atm
        [HttpPut("/UpdateNameOfEmployee/id{id:int}/{name}")]
        public async Task<IActionResult> UpdateEmployee(int id, string name) {

            var res = await _employee.GetSingle(id);
            if (res != null) {
                Employee updated = new Employee {
                    EmployeeId = id,
                    Name = name
                };
                await _employee.Update(updated);
                return Ok(updated); 
            }
            return NotFound($"Employee with Id : {id} was not found...");

        }

        [HttpPost]
        public async Task<IActionResult> NewEmployee(Employee employee) {

            try {
                if (employee == null)
                    return BadRequest();

                var newEmployee = await _employee.Add(employee);
                return CreatedAtAction(nameof(GetEmployee), new { Id = employee.EmployeeId }, newEmployee);

            } catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add employee...");
            }

        }

        [HttpDelete("/DeleteEmployee/id{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id) {

            var res = await _employee.GetSingle(id);
            if (res != null) {
                await _employee.Delete(id);
                return Ok(res);
            }
            return NotFound($"Employee with Id : {id} was not found...");

        }
        [HttpGet("/GetEmployeesForProject/id{id:int}")]
        public async Task<IActionResult> GetEmployeesForProject(int id)
        {
            var res = await _employee.GetEmployeesForProject(id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound($"A project with the Id : {id} did not have any employees working on it");
        }
    }
}
