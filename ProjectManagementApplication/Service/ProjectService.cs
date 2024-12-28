using ProjectManagementApplication.Abstractions;
using ProjectManagementApplication.IRepository;
using ProjectManagementApplication.IService;
using ProjectManagementCore.Entities;

namespace ProjectManagementApplication.Service
{
    internal class ProjectService :IProjectService, IScopedLifestyle
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _projectRepository.GetProjectsAsync();
        }
        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetProjectByIdAsync(id);
        }

        public async Task AddProjectAsync(Project project)
        {
            await _projectRepository.AddProjectAsync(project);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            await _projectRepository.UpdateProjectAsync(project);
        }

        


        
    }
}
