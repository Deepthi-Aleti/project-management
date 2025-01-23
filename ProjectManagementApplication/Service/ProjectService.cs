using ProjectManagementApplication.Abstractions;
using ProjectManagementApplication.DTO;
using ProjectManagementApplication.IRepository;
using ProjectManagementApplication.IService;
using ProjectManagementApplication.Utils;
using ProjectManagementCore.Entities;
using ProjectManagementDomain.Enum;

namespace ProjectManagementApplication.Service
{
    public class ProjectService :IProjectService, IScopedLifestyle
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

        //public async Task<List<ProjectDetailsDto>> GetProjectsAsync()
        //{
        //    var projects = await _projectRepository.GetProjectsAsync();
        //    //return projects.Select(project => _mapper.Map<ProjectDetailsDto>(project)).ToList();
        //    return projects.Select(item => item.MapToProjectDetailsDto());
        //}



        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetProjectByIdAsync(id);
        }

        public async Task AddProjectAsync(ProjectDetailsDto project)
        {
            var newProject = project.MapToProjectEntity();
            await _projectRepository.AddProjectAsync(newProject);
        }

        public async Task<bool> UpdateProjectAsync(int id,ProjectDetailsDto projectDto)
        {
            var projectEnitiy = await _projectRepository.GetProjectByIdAsync(id);
            if(projectEnitiy == null)
            {
                return false;
            }
            projectEnitiy.UpdateProjectEntity(projectDto);

            await _projectRepository.UpdateProjectAsync(projectEnitiy);
            return true;
        }

        public async Task<IEnumerable<ProjectDetailsDto>> GetProjectByCategoryAsync(ProjectCategory category)
        {
            var projects = (await _projectRepository.GetProjectsAsync()).Where(items => items.Category == category);
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
