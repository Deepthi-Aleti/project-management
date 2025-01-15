using Microsoft.EntityFrameworkCore;
using ProjectManagementApplication.Abstractions;
using ProjectManagementApplication.IRepository;
using ProjectManagementCore.Entities;
using ProjectManagementInfrastructure;

namespace ProjectManagementApplication.Repositories
{
    public class ProjectRepository : IProjectRepository, IScopedLifestyle
    {
        private readonly ApplicationDbContext _dbContext;
        public ProjectRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _dbContext.Projects.Include(p => p.Teams).Include(p => p.Clients).ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(p=>p.ProjectId==id);
        }

        public async Task<int> AddProjectAsync(Project project)
        {
            _dbContext.Projects.Add(project);
            return await _dbContext.SaveChangesAsync();
        }

        public Task UpdateProjectAsync(Project project)
        {
            project.LastUpdated = DateTime.UtcNow; 
            //project.LastUpdatedBy = userName;

            _dbContext.Projects.Update(project);
            return _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Project project)
        {
            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();
        }



        //public void AddProject(Project project)
        //{
        //    _dbContext.Projects.Add(project);   
        //}

        //public IEnumerable<Project> GetProjects()
        //{
        //    return _dbContext.Projects;
        //}





        //public void UpdateProject(Project project)
        //{
        //    var existingProjectDetails = _dbContext.Projects.FirstOrDefault(item => item.Id == project.Id);
        //    existingProjectDetails.Name = project.Name;
        //    existingProjectDetails.Domain = project.Domain;
        //    _dbContext.SaveChanges();
        //}
    }
}
