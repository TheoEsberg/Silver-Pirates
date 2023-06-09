﻿using Microsoft.AspNetCore.Mvc;
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

        // Get all EmployeeProject connections
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeProject.GetAll());
        }
        //Adds a new EmployeeProject connection
        [HttpPost]
        public async Task<IActionResult> NewEmployeeProject(int employeeId,int projectId)
        {
            try
            {
                var newEmployeeProject = await _employeeProject.Add(employeeId, projectId);
                return Ok(newEmployeeProject);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add hour report...");
            }
        }

        // Get a single EmployeeProject connection by EmployeeProjectId
        [HttpGet("/GetEmployeeProject/id{id:int}")]
        public async Task<IActionResult> GetEmployeeProject(int id) 
        {
            var res = await _employeeProject.GetSingle(id);
            if (res != null) 
            {
                return Ok(res);
            }
            return NotFound($"Employee with Id : {id} was not found...");
        }

        // Update a EmployeeProject connection by EmployeeProjectId
        [HttpPut("/UpdateEmployeeProject/id{id:int}/employeeId/projectId")]
        public async Task<IActionResult> UpdateEmployeeProject(int id, int employeeId, int projectId) 
        {
            var res = await _employeeProject.GetSingle(id);
            if (res != null) 
            {
                EmployeeProject updated = new EmployeeProject 
                {
                    EmployeeProjectId = id,
                    EmployeeId = employeeId,
                    ProjectId = projectId
                };
                await _employeeProject.Update(updated);
                return Ok(updated);
            }
            return NotFound($"EmployeeProject with Id : {id} was not found...");
        }
        [HttpDelete("/DeleteEmployeeProject/id{id:int}")]
        public async Task<IActionResult> DeleteEmployeeProject(int id)
        {
            var res = await _employeeProject.GetSingle(id);
            if (res != null)
            {
                await _employeeProject.Delete(id);
                return Ok(res);
            }
            return NotFound($"EmployeeProject with Id : {id} was not found...");
        }
    }
}
