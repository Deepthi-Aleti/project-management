using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementDomain.Entities;

namespace ProjectManagementApplication.IRepository
{
    public interface ITeamRepository
    {

        Task<List<Teams>> GetAllTeamsAsync();
        Task<Teams> GetTeamByIdAsync(int id);
    }
}
