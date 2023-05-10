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

        // Get all employees
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employee.GetAll();
            return Ok(employees);
        }

        // Get employee by EmployeeId
        [HttpGet("/GetEmployee/id{id:int}")]
        public async Task<IActionResult> GetEmployee(int id) {

            var res = await _employee.GetSingle(id);
            if (res != null) {
                return Ok(res);
            }
            return NotFound($"Employee with Id : {id} was not found...");

        }

        // Update the name of the employee by employeeId & name
        [HttpPut("/UpdateNameOfEmployee/id{id:int}/{name}")]
        public async Task<IActionResult> UpdateEmployee(int id, string name) 
        {
            var res = await _employee.GetSingle(id);
            if (res != null) 
            {
                Employee updated = new Employee 
                {
                    EmployeeId = id,
                    Name = name
                };
                await _employee.Update(updated);
                return Ok(updated); 
            }
            return NotFound($"Employee with Id : {id} was not found...");
        }

        // Add a new Employee
        [HttpPost]
        public async Task<IActionResult> NewEmployee(Employee employee) 
        {
            try 
            {
                if (employee == null)
                    return BadRequest();

                var newEmployee = await _employee.Add(employee);
                return CreatedAtAction(nameof(GetEmployee), new { Id = employee.EmployeeId }, newEmployee);
            } 
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add employee...");
            }
        }

        // Delete an existing Employee by EmployeeId
        [HttpDelete("/DeleteEmployee/id{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id) 
        {
            var res = await _employee.GetSingle(id);
            if (res != null) 
            {
                await _employee.Delete(id);
                return Ok(res);
            }
            return NotFound($"Employee with Id : {id} was not found...");
        }

        // Get all the Employees on a Project by ProjectId
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
