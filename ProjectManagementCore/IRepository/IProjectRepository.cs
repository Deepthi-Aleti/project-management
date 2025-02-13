using ProjectManagementCore.Entities;

namespace ProjectManagementApplication.IRepository
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task<int> AddProjectAsync(Project project);
        Task<bool> UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);

    }
}
