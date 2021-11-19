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

        public DbSet<BugHistoryRecord> BugHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>().HasMany(p => p.Developers)
                .WithMany(d => d.Projects)
                .Map(c =>
                {
                    c.MapLeftKey("project_id");
                    c.MapRightKey("developer_id");
                    c.ToTable("projects_developers");
                });
        }
    }
}
