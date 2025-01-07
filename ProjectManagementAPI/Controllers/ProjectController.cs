using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApplication.DTO;
using ProjectManagementApplication.IService;
using ProjectManagementCore.Entities;
using ProjectManagementDomain.Enum;

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
        public async Task<IActionResult> GetProjectsByCategoryAsync(ProjectCategory category)
        {
            var projects= await _projectService.GetProjectByCategoryAsync(category);
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
        public async Task<IActionResult> CreateProject([FromBody] ProjectDetailsDto project)
        {
            await _projectService.AddProjectAsync(project);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectDetailsDto project)
        {

            var isUpdateSuccess = await _projectService.UpdateProjectAsync(id, project);
            if(!isUpdateSuccess)
            {
                return NotFound($"Project with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
