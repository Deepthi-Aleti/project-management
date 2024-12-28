using ProjectManagementCore.Entities;

namespace ProjectManagementApplication.IService
{
    public interface IProjectService
    {
        //Task<IEnumerable<Project>> GetPojectDetails();
        //Task AddProject(Project project);

        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
    }
}
