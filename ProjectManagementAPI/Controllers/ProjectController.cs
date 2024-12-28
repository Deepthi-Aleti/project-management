using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApplication.IService;
using ProjectManagementCore.Entities;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;   
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects= await _projectService.GetProjectsAsync();
            return Ok(projects);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            await _projectService.AddProjectAsync(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = project.ProjectId }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }
            await _projectService.UpdateProjectAsync(project);
            return NoContent();
        }
    }
}
