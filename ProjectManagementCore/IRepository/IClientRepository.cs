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
        public Task<IEnumerable<Clients>> GetAllClientsAsync();
    }
}
