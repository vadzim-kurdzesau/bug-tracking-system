using System.Data.Entity;
using BugTrackingSystem.Models;

namespace BugTrackingSystem
{
    public class BugTrackingSystemContext : DbContext
    {
        public BugTrackingSystemContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<BugType> BugTypes { get; set; }

        public DbSet<BugStatus> BugStatuses { get; set; }

        public DbSet<Bug> Bugs { get; set; }

        public DbSet<BugsAuditRecord> BugsAudit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasMany(p => p.Developers)
                .WithMany(d => d.Projects)
                .Map(c =>
                {
                    c.MapLeftKey("project_id");
                    c.MapRightKey("developer_id");
                    c.ToTable("projects_developers");
                });

            modelBuilder.Entity<Project>().HasMany(p => p.Bugs)
                .WithRequired(b => b.Project);

            modelBuilder.Entity<BugStatus>().HasMany(s => s.Bugs)
                .WithRequired(b => b.BugStatus);

            modelBuilder.Entity<BugType>().HasMany(t => t.Bugs)
                .WithRequired(b => b.BugType);

            modelBuilder.Entity<Developer>().HasMany(d => d.Bugs)
                .WithOptional(b => b.Developer);
        }
    }
}
