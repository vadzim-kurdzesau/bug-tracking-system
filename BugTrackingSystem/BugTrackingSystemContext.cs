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

        public DbSet<ProjectsDevelopers> ProjectsDevelopers { get; set; }

        public DbSet<BugType> BugTypes { get; set; }

        public DbSet<BugStatus> BugStatuses { get; set; }

        public DbSet<Bug> Bugs { get; set; }

        public DbSet<BugHistoryRecord> BugHistory { get; set; }
    }
}
