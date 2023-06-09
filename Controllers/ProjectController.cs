﻿using Microsoft.AspNetCore.Mvc;
using Silver_Pirates.Services;
using Silver_Pirates_API;

namespace Silver_Pirates.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProject<Project> _project;
        public ProjectController(IProject<Project> project)
        {
            this._project = project;
        }

        // Get all Projects
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _project.GetAll());
        }

        // Get a Projects by ProjectControllerId
        [HttpGet("ProjectId")]
        public async Task<IActionResult> GetProject(int id) 
        {
            var res = await _project.GetSingle(id);
            if (res != null)
                return Ok(res);

            return NotFound($"Project with {id} was not found...");
        }

        // Update a name of a Project by ProjectId
        [HttpPut("/UpdateNameOfProject/id{id:int}/{name}")]
        public async Task<IActionResult> UpdateProject(int id, string name) 
        {
            var res = await _project.GetSingle(id);
            if (res != null) 
            {
                Project updated = new Project 
                {
                    ProjectId = id,
                    Name = name
                };
                await _project.Update(updated);
                return Ok(updated);
            }
            return NotFound($"Project with Id : {id} was not found...");
        }

        // Add a new Project 
        [HttpPost]
        public async Task<IActionResult> NewProject(string projectName) 
        {
            try 
            {
                if (projectName == null)
                    return BadRequest();

                var newProject = await _project.Add(projectName);
                return Ok(newProject);
            } 
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to add project...");
            }
        }

        // Delete an existing Project by ProjectId
        [HttpDelete("/DeleteProject/id{id:int}")]
        public async Task<IActionResult> DeleteProject(int id) 
        {
            var res = await _project.GetSingle(id);
            if (res != null) 
            {
                await _project.Delete(id);
                return Ok(res);
            }
            return NotFound($"Project with Id : {id} was not found...");
        }
    }
}
