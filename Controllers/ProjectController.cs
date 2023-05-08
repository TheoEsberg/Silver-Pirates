using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_project.GetAll());
        }

        [HttpGet("ProjectId")]
        public IActionResult GetEmployee(int id) {
            var res = _project.GetSingle(id);
            if (res != null)
                return Ok(res);

            return NotFound($"Employee with {id} was not found...");
        }
    }
}
