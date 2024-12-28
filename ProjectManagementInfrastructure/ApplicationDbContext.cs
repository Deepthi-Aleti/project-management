using Microsoft.EntityFrameworkCore;
using ProjectManagementCore.Entities;
using ProjectManagementDomain.Entities;



namespace ProjectManagementInfrastructure
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Clients> Clients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Clients>()
            .HasKey(c => c.ClientId);
            modelBuilder.Entity<Teams>()
            .HasKey(t => t.TeamId);
            modelBuilder.Entity<Project>()
            .HasKey(p => p.ProjectId);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Teams)
                .WithMany()
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Clients)
                .WithMany()
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            
            modelBuilder.Entity<Teams>().Property(t => t.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Clients>().Property(t => t.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Clients>().Property(c => c.Email).HasMaxLength(255);



            modelBuilder.Entity<Teams>().HasData(
                new Teams { TeamId = 1, Name = "Development", Size = 10, Location = "Hyderabad", IsActive = true, IsDeleted = false, CreatedOn = DateTime.UtcNow, CreatedBy = "Admin" ,LastUpdatedBy="Admin"},
                new Teams { TeamId = 2, Name = "Marketing", Size = 6, Location = "Bangalore", IsActive = true, IsDeleted = false, CreatedOn = DateTime.UtcNow, CreatedBy = "Admin", LastUpdatedBy = "Admin" },
                new Teams { TeamId = 3, Name = "Design", Size = 5, Location = "Chennai", IsActive = false, IsDeleted = false, CreatedOn = DateTime.UtcNow, CreatedBy = "Admin", LastUpdatedBy = "Admin" }
            );

            // Seed data for Clients
            modelBuilder.Entity<Clients>().HasData(
                new Clients { ClientId = 1, Name = "ABC Corp", Country = "USA", Location = "New York", Email = "contact@abccorp.com", Phone = "123-456-7890", IsActive = true, IsDeleted = false, CreatedOn = DateTime.UtcNow, CreatedBy = "Admin" },
                new Clients { ClientId = 2, Name = "XYZ Pvt Ltd", Country = "UK", Location = "London", Email = "info@xyzltd.com", Phone = "987-654-3210", IsActive = true, IsDeleted = false, CreatedOn = DateTime.UtcNow, CreatedBy = "Admin" },
                new Clients { ClientId = 3, Name = "Tech Innovators", Country = "India", Location = "Mumbai", Email = "hello@techinnovators.in", Phone = "555-555-5555", IsActive = true, IsDeleted = false, CreatedOn = DateTime.UtcNow, CreatedBy = "Admin" }
            );

            // Seed data for Projects
            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, Name = "Project Zen", Domain = "Software Development", ReleaseDate = DateTime.Now.AddMonths(2), TentativeDate = DateTime.Now.AddMonths(3), TeamId = 1, ClientId = 1, IsActive = true, IsDeleted = false, CreatedOn = DateTime.UtcNow, CreatedBy = "Admin",LastUpdatedBy="Admin"},
                new Project { ProjectId = 2, Name = "Project Lamda", Domain = "Marketing Campaign", ReleaseDate = DateTime.Now.AddMonths(1), TentativeDate = DateTime.Now.AddMonths(2), TeamId = 2, ClientId = 2, IsActive = true, IsDeleted = false, CreatedOn = DateTime.UtcNow, CreatedBy = "Admin", LastUpdatedBy = "Admin" },
                new Project { ProjectId = 3, Name = "Project CAT", Domain = "Product Design", ReleaseDate = DateTime.Now.AddMonths(4), TentativeDate = DateTime.Now.AddMonths(5), TeamId = 3, ClientId = 3, IsActive = false, IsDeleted = false, CreatedOn = DateTime.UtcNow, CreatedBy = "Admin", LastUpdatedBy = "Admin" }
            );
        }

    }
}
