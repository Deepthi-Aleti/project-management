
using MongoDB.Driver;
using ProjectManagementApplication.IRepository;
using ProjectManagementDomain.Entities;

namespace ProjectManagementInfrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMongoCollection<Clients> _clientsCollection;

        public ClientRepository(IMongoDatabase database)
        {
            _clientsCollection = database.GetCollection<Clients>("Clients");
        }

        public async Task<IEnumerable<Clients>> GetAllClientsAsync()
        {
            return await _clientsCollection.Find(_ => true).ToListAsync();
        }
    }
}
