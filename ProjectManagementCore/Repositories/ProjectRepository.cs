using MongoDB.Driver;
using ProjectManagementApplication.IRepository;
using ProjectManagementCore.Entities;
using ProjectManagementDomain.Entities;

namespace ProjectManagementApplication.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IMongoCollection<Project> _projectsCollection;
        private readonly IMongoCollection<Teams> _teamsCollection;
        private readonly IMongoCollection<Clients> _clientsCollection;

        public ProjectRepository(IMongoDatabase database)
        {
            _projectsCollection = database.GetCollection<Project>("Projects");
            _teamsCollection = database.GetCollection<Teams>("Teams");
            _clientsCollection = database.GetCollection<Clients>("Clients");
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var projects = await _projectsCollection.Find(_ => true).ToListAsync();
            foreach (var project in projects)
            {
                project.Teams = await _teamsCollection.Find(t => t.TeamId == project.TeamId).FirstOrDefaultAsync();
                project.Clients = await _clientsCollection.Find(c => c.ClientId == project.ClientId).FirstOrDefaultAsync();
            }

            return projects;
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var project = await _projectsCollection.Find(p => p.ProjectId == id).FirstOrDefaultAsync();
            project.Teams = await _teamsCollection.Find(t => t.TeamId == project.TeamId).FirstOrDefaultAsync();
            project.Clients = await _clientsCollection.Find(c => c.ClientId == project.ClientId).FirstOrDefaultAsync();
            return project;
        }

        public async Task<int> AddProjectAsync(Project project)
        {
            var lastProject = await _projectsCollection
                .Find(_ => true)
                .SortByDescending(p => p.ProjectId)
                .Limit(1)
                .FirstOrDefaultAsync();

            int nextProjectId = (lastProject != null) ? lastProject.ProjectId + 1 : 1; // Default to 1 if DB is empty

            project.ProjectId = nextProjectId;

            await _projectsCollection.InsertOneAsync(project);
            return project.ProjectId;
        }


        public async Task<bool> UpdateProjectAsync(Project project)
        {
            project.LastUpdated = DateTime.UtcNow;
            var result = await _projectsCollection.ReplaceOneAsync(p => p.ProjectId == project.ProjectId, project);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }


        public async Task DeleteProjectAsync(Project project)
        {
            var filter = Builders<Project>.Filter.Eq(p => p.ProjectId, project.ProjectId);
            await _projectsCollection.DeleteOneAsync(filter);
        }
    }
}
