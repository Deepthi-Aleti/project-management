using ProjectManagementApplication.DTO;
using ProjectManagementCore.Entities;
using ProjectManagementDomain.Entities;

namespace ProjectManagementApplication.Utils
{
    public static class DataMapperUtils
    {
        public static ProjectDetailsDto MapToProjectDetailsDto(this Project project)
        {
            return new ProjectDetailsDto
            {
                Id = project.ProjectId,
                Name = project.Name,
                Domain = project.Domain,
                Category = project.Category,
                TeamId = project.TeamId,
                ClientId = project.ClientId,
                TeamName = project.Teams?.Name, // Null-conditional operator
                ClientName = project.Clients?.Name, // Null-conditional operator
                ReleaseDate = DateOnly.FromDateTime(project.ReleaseDate).ToShortDateString(),
            };
        }
        public static TeamDetailsDto MapToTeamDetailsDto(this Teams team)
        {
            return new TeamDetailsDto
            {
                TeamId = team.TeamId,
                TeamName = team.Name
            };
        }

        public static ClientDetailsDto MapToClientDetailsDto(this Clients client)
        {
            return new ClientDetailsDto
            {
                ClientId = client.ClientId,
                ClientName = client.Name
            };
        }

        public static Project MapToProjectEntity(this ProjectDetailsDto projectDetailsDto)
        {
            return new Project
            {
                Name = projectDetailsDto.Name,
                Category = projectDetailsDto.Category,
                Domain = projectDetailsDto.Domain,
                ReleaseDate = DateTime.Parse(projectDetailsDto.ReleaseDate).ToUniversalTime(),
                TeamId = projectDetailsDto.TeamId,
                ClientId = projectDetailsDto.ClientId,
                IsActive = true,
                IsDeleted = false,
                LastUpdated = DateTime.UtcNow,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "admin",
                LastUpdatedBy = "admin",
            };
        }

        public static void UpdateProjectEntity(this Project projectEntity, ProjectDetailsDto projectDetailsDto)
        {
            projectEntity.Name = projectDetailsDto.Name;
            projectEntity.Category = projectDetailsDto.Category;
            projectEntity.Domain = projectDetailsDto.Domain;
            projectEntity.TeamId = projectDetailsDto.TeamId;
            projectEntity.ClientId = projectDetailsDto.ClientId;
        }
    }
}
