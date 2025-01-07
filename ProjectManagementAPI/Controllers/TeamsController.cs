using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementApplication.IService;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamsService;   
        public TeamsController(ITeamService teamService)
        {
            _teamsService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamsDetailsAsync()
        {
            var teamsData = await _teamsService.GetTeamDetailsAsync(); 
            return Ok(teamsData);
        }
    }
}
