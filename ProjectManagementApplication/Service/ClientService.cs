using ProjectManagementApplication.DTO;
using ProjectManagementApplication.IRepository;
using ProjectManagementApplication.IService;
using ProjectManagementApplication.Utils;

namespace ProjectManagementApplication.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<IEnumerable<ClientDetailsDto>> GetClientDetailsAsync()
        {
            var clientData = await _clientRepository.GetAllClientsAsync();
            return clientData.Select(client => client.MapToClientDetailsDto());
        }
    }
}
