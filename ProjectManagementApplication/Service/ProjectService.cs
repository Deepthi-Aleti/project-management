using ProjectManagementApplication.DTO;
using ProjectManagementApplication.IRepository;
using ProjectManagementApplication.IService;
using ProjectManagementApplication.Utils;
using ProjectManagementDomain.Enum;

namespace ProjectManagementApplication.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectDetailsDto>> GetProjectsAsync()
        {
            var projects = await _projectRepository.GetProjectsAsync();
            return projects.Select(item => item.MapToProjectDetailsDto());
        }

        public async Task<ProjectDetailsDto> GetProjectByIdAsync(int id)
        {
            var projects= await _projectRepository.GetProjectByIdAsync(id);
            return projects.MapToProjectDetailsDto();
        }

        public async Task AddProjectAsync(ProjectDetailsDto project)
        {
            var newProject = project.MapToProjectEntity();
            await _projectRepository.AddProjectAsync(newProject);
        }

        public async Task<bool> UpdateProjectAsync(int id, ProjectDetailsDto projectDto)
        {
            var projectEntity = await _projectRepository.GetProjectByIdAsync(id);
            if (projectEntity == null)
            {
                return false;
            }

            projectEntity = projectEntity.UpdateProjectEntity(projectDto);
            return await _projectRepository.UpdateProjectAsync(projectEntity);
        }
        public async Task<IEnumerable<ProjectDetailsDto>> GetProjectByCategoryAsync(ProjectCategory category)
        {
            var projects = (await _projectRepository.GetProjectsAsync())
                .Where(items => items.Category == category);
            return projects.Select(item => item.MapToProjectDetailsDto());
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var projectEntity = await _projectRepository.GetProjectByIdAsync(id);
            if (projectEntity == null)
            {
                return false;
            }

            await _projectRepository.DeleteProjectAsync(projectEntity);
            return true;
        }
    }
}
