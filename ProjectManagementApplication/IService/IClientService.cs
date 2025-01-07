using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementApplication.DTO;

namespace ProjectManagementApplication.IService
{
    public interface IClientService
    {
        public Task<IEnumerable<ClientDetailsDto>> GetClientDetailsAsync(); 
    }
}
