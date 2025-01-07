using Microsoft.EntityFrameworkCore;
using ProjectManagementCore.Entities;
using ProjectManagementDomain.Entities;
using ProjectManagementDomain.Enum;

namespace ProjectManagementInfrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Clients> Clients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Default schema
            modelBuilder.HasDefaultSchema("project_management");

            // Clients configuration
            modelBuilder.Entity<Clients>(entity =>
            {
                entity.ToTable("Clients");
                entity.HasKey(c => c.ClientId);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Email).HasMaxLength(255);
                entity.HasIndex(c => c.Email).IsUnique();
            });

            // Teams configuration
            modelBuilder.Entity<Teams>(entity =>
            {
                entity.ToTable("Teams");
                entity.HasKey(t => t.TeamId);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
            });

            // Projects configuration
            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Projects");
                entity.HasKey(p => p.ProjectId);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.HasOne(p => p.Clients)
                      .WithMany()
                      .HasForeignKey(p => p.ClientId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(p => p.Teams)
                      .WithMany()
                      .HasForeignKey(p => p.TeamId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
