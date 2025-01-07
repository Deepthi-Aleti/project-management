using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementApplication.DTO;
using ProjectManagementApplication.IRepository;
using ProjectManagementApplication.IService;
using ProjectManagementApplication.Utils;

namespace ProjectManagementApplication.Service
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;
        public TeamService(ITeamRepository teamRepository)
        {
            _repository = teamRepository;
        }

        public async Task<IEnumerable<TeamDetailsDto>> GetTeamDetailsAsync()
        {
           var teams = await _repository.GetAllTeamsAsync();
            return teams.Select(team => team.MapToTeamDetailsDto());
        }
    }
}
