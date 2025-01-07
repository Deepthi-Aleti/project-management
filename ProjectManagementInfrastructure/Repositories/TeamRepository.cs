using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApplication.IRepository;
using ProjectManagementDomain.Entities;

namespace ProjectManagementInfrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<Teams>> GetAllTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public Task<Teams> GetTeamByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
