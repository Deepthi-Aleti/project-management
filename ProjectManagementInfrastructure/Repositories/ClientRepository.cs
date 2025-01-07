using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApplication.IRepository;
using ProjectManagementDomain.Entities;

namespace ProjectManagementInfrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<Clients>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public Task<Clients> GetClientByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
