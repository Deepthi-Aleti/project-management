using ProjectManagementApplication.DTO;
using ProjectManagementCore.Entities;
using ProjectManagementDomain.Enum;

namespace ProjectManagementApplication.IService
{
    public interface IProjectService
    {
        //Task<IEnumerable<Project>> GetPojectDetails();
        //Task AddProject(Project project);

        Task<IEnumerable<ProjectDetailsDto>> GetProjectsAsync();
        
        Task<ProjectDetailsDto> GetProjectByIdAsync(int id);

        Task<IEnumerable<ProjectDetailsDto>> GetProjectByCategoryAsync(ProjectCategory category);
        Task AddProjectAsync(ProjectDetailsDto project);
        Task<bool> UpdateProjectAsync(int id, ProjectDetailsDto project);
        Task<bool> DeleteProjectAsync(int id);
    }
}
