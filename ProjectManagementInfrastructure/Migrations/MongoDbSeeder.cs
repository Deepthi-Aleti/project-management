using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using ProjectManagementCore.Entities;
using ProjectManagementDomain.Entities;

public class MongoDbSeeder
{
    private readonly IMongoDatabase _database;

    public MongoDbSeeder(IMongoDatabase database)
    {
        _database = database;
    }

    public async Task SeedAsync()
    {
        await SeedClientsAsync();
        await SeedTeamsAsync();
        await SeedProjectsAsync();
    }

    private async Task SeedClientsAsync()
    {
        var clientsCollection = _database.GetCollection<Clients>("Clients");

        if (await clientsCollection.CountDocumentsAsync(_ => true) == 0) // Insert only if empty
        {
            var clients = new List<Clients>
            {
                new Clients { ClientId = 100, Name = "Cloud Angles", Country = "India", Location = "Hyderabad", Email = "test@abc.com", Phone = "0000000000", IsActive = true, IsDeleted = false, CreatedOn = new DateTime(2024, 12, 30), CreatedBy = "admin" },
                new Clients { ClientId = 101, Name = "ML Angles", Country = "USA", Location = "California", Email = "test@abdc.com", Phone = "1111111111", IsActive = true, IsDeleted = false, CreatedOn = new DateTime(2024, 12, 30), CreatedBy = "admin" }
            };

            await clientsCollection.InsertManyAsync(clients);
        }
    }

    private async Task SeedTeamsAsync()
    {
        var teamsCollection = _database.GetCollection<Teams>("Teams");

        if (await teamsCollection.CountDocumentsAsync(_ => true) == 0)
        {
            var teams = new List<Teams>
            {
                new Teams { TeamId = 10, Name = "DotNet_Team", Size = 5, Location = "Hyderabad", IsActive = true, IsDeleted = false, CreatedOn = new DateTime(2024, 12, 30), CreatedBy = "admin", LastUpdatedOn = new DateTime(2024, 12, 30), LastUpdatedBy = "admin" },
                new Teams { TeamId = 11, Name = "Power Platform_Team", Size = 8, Location = "Noida", IsActive = true, IsDeleted = false, CreatedOn = new DateTime(2024, 12, 30), CreatedBy = "admin", LastUpdatedOn = new DateTime(2024, 12, 30), LastUpdatedBy = "admin" },
                new Teams { TeamId = 12, Name = "CRM_Team", Size = 4, Location = "Hyderabad", IsActive = true, IsDeleted = false, CreatedOn = new DateTime(2024, 12, 30), CreatedBy = "admin", LastUpdatedOn = new DateTime(2024, 12, 30), LastUpdatedBy = "admin" }
            };

            await teamsCollection.InsertManyAsync(teams);
        }
    }

    private async Task SeedProjectsAsync()
    {
        var projectsCollection = _database.GetCollection<Project>("Projects");

        var existingProjects = await projectsCollection.Find(_ => true).ToListAsync();
        int nextProjectId = existingProjects.Any() ? existingProjects.Max(p => p.ProjectId) + 1 : 1;

        var projects = new List<Project>
{
            new Project { ProjectId = nextProjectId++, Name = "Hello", Domain = "Cloud1", Category = (ProjectManagementDomain.Enum.ProjectCategory)2, ReleaseDate = new DateTime(2025, 1, 28), TentativeDate = null, TeamId = 10, ClientId = 100, IsActive = true, IsDeleted = false, LastUpdated = new DateTime(2025, 1, 27, 10, 43, 37), CreatedOn = new DateTime(2025, 1, 27, 10, 43, 37), CreatedBy = "admin", LastUpdatedBy = "admin", description = "No description available." },
    new Project { ProjectId = nextProjectId++, Name = "1111", Domain = "Cloud", Category = 0, ReleaseDate = new DateTime(2025, 2, 27), TentativeDate = null, TeamId = 10, ClientId = 100, IsActive = true, IsDeleted = false, LastUpdated = new DateTime(2025, 2, 11, 11, 38, 32), CreatedOn = new DateTime(2025, 2, 11, 11, 38, 32), CreatedBy = "admin", LastUpdatedBy = "admin", description = "" },
    new Project { ProjectId = nextProjectId++, Name = "Test14", Domain = "E-commerce", Category = 0, ReleaseDate = new DateTime(2025, 2, 26), TentativeDate = null, TeamId = 10, ClientId = 100, IsActive = true, IsDeleted = false, LastUpdated = new DateTime(2025, 2, 11, 12, 00, 12), CreatedOn = new DateTime(2025, 2, 11, 12, 00, 12), CreatedBy = "admin", LastUpdatedBy = "admin", description = "" },
    new Project { ProjectId = nextProjectId++, Name = "Test project 3", Domain = "Construction", Category = (ProjectManagementDomain.Enum.ProjectCategory)1, ReleaseDate = new DateTime(2025, 4, 30, 22, 16, 51), TentativeDate = new DateTime(2025, 5, 31, 22, 16, 51), TeamId = 12, ClientId = 101, IsActive = true, IsDeleted = false, LastUpdated = new DateTime(2024, 12, 31), CreatedOn = new DateTime(2024, 12, 31, 16, 46, 51), CreatedBy = "admin", LastUpdatedBy = "admin", description = "Project 3 is focused on constructing state-of-the-art facilities designed to foster innovation in the construction industry. The project includes the design and development of sustainable, eco-friendly structures that meet modern standards of efficiency and safety." },
    new Project { ProjectId = nextProjectId++, Name = "sample 2", Domain = "health", Category = (ProjectManagementDomain.Enum.ProjectCategory)1, ReleaseDate = new DateTime(2024, 12, 26), TentativeDate = null, TeamId = 11, ClientId = 100, IsActive = true, IsDeleted = false, LastUpdated = new DateTime(2024, 12, 31, 17, 59, 28), CreatedOn = new DateTime(2024, 12, 31, 17, 59, 28), CreatedBy = "admin", LastUpdatedBy = "admin", description = "Sample 2 is a healthcare project that focuses on improving the delivery of medical services through innovative technologies. The project aims to optimize patient care, streamline processes, and enhance the overall healthcare experience." },
    new Project { ProjectId = nextProjectId++, Name = "CloudAngles", Domain = "Cloud", Category = 0, ReleaseDate = new DateTime(2025, 1, 23), TentativeDate = null, TeamId = 10, ClientId = 100, IsActive = true, IsDeleted = false, LastUpdated = new DateTime(2025, 1, 16, 15, 00, 43), CreatedOn = new DateTime(2025, 1, 16, 15, 00, 43), CreatedBy = "admin", LastUpdatedBy = "admin", description = "Cloud project focuses on developing cutting-edge cloud-based solutions for businesses to scale and manage their operations more effectively. By leveraging cloud infrastructure, the project enables businesses to reduce costs, increase efficiency, and enhance collaboration." },
    new Project { ProjectId = nextProjectId++, Name = "Cloud Domain", Domain = "Cloud", Category = 0, ReleaseDate = new DateTime(2025, 1, 22), TentativeDate = null, TeamId = 10, ClientId = 100, IsActive = true, IsDeleted = false, LastUpdated = new DateTime(2025, 1, 16, 15, 01, 14), CreatedOn = new DateTime(2025, 1, 16, 15, 01, 14), CreatedBy = "admin", LastUpdatedBy = "admin", description = "Cloud project focuses on developing cutting-edge cloud-based solutions for businesses to scale and manage their operations more effectively. By leveraging cloud infrastructure, the project enables businesses to reduce costs, increase efficiency, and enhance collaboration." },
    new Project { ProjectId = nextProjectId++, Name = "abc", Domain = "Education", Category = 0, ReleaseDate = new DateTime(2025, 1, 30), TentativeDate = null, TeamId = 10, ClientId = 100, IsActive = true, IsDeleted = false, LastUpdated = new DateTime(2025, 1, 16, 15, 01, 52), CreatedOn = new DateTime(2025, 1, 16, 15, 01, 52), CreatedBy = "admin", LastUpdatedBy = "admin", description = "Education project focuses on developing modern, interactive platforms designed to enhance learning experiences for students. It includes tools for virtual classrooms, remote learning, and skill-building courses to empower learners of all ages." },
    new Project { ProjectId = nextProjectId++, Name = "abc2", Domain = "ecommerce", Category = 0, ReleaseDate = new DateTime(2025, 1, 24), TentativeDate = null, TeamId = 10, ClientId = 100, IsActive = true, IsDeleted = false, LastUpdated = new DateTime(2025, 1, 21, 10, 56, 58), CreatedOn = new DateTime(2025, 1, 21, 10, 56, 58), CreatedBy = "admin", LastUpdatedBy = "admin", description = "No description available." },
    new Project { ProjectId = nextProjectId++, Name = "sample1", Domain = "ecommerce", Category = 0, ReleaseDate = new DateTime(2024, 12, 31), TentativeDate = new DateTime(2024, 12, 31), TeamId = 12, ClientId = 101, IsActive = true, IsDeleted = false, LastUpdated = new DateTime(2025, 1, 23, 17, 02, 09), CreatedOn = new DateTime(2024, 12, 31), CreatedBy = "admin", LastUpdatedBy = "admin", description = "No description available." },
    new Project { ProjectId = nextProjectId++, Name = "BOT1", Domain = "Cloud1", Category = (ProjectManagementDomain.Enum.ProjectCategory)2, ReleaseDate = new DateTime(2025, 1, 28), TentativeDate = null, TeamId = 10, ClientId = 100, IsActive = true, IsDeleted = false, LastUpdated = new DateTime(2025, 1, 27, 10, 43, 37), CreatedOn = new DateTime(2025, 1, 27, 10, 43, 37), CreatedBy = "admin", LastUpdatedBy = "admin", description = "No description available." }
};

        foreach (var project in projects)
        {
            var exists = await projectsCollection.Find(p => p.ProjectId == project.ProjectId || p.Name == project.Name).AnyAsync();
            if (!exists)
            {
                await projectsCollection.InsertOneAsync(project);
            }
        }
    }
}
