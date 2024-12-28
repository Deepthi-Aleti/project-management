using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementDomain.Entities;

namespace ProjectManagementApplication.IRepository
{
    public interface IClientRepository
    {
        Task<List<Clients>> GetAllClientsAsync();
        Task<Clients> GetClientByIdAsync(int id);
    }
}
