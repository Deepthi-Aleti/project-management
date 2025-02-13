using MongoDB.Driver;
using ProjectManagementApplication.IRepository;
using ProjectManagementDomain.Entities;

namespace ProjectManagementInfrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly IMongoCollection<Teams> _teamsCollection;

        public TeamRepository(IMongoDatabase database)
        {
            _teamsCollection = database.GetCollection<Teams>("Teams");
        }

        public async Task<IEnumerable<Teams>> GetAllTeamsAsync()
        {
            return await _teamsCollection.Find(_ => true).ToListAsync();
        }
    }
}
