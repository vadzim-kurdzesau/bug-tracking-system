using BugTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTrackingSystem
{
    public class BugTrackingSystemContext : DbContext
    {
        public BugTrackingSystemContext()
        {
        }

        public BugTrackingSystemContext(DbContextOptions<BugTrackingSystemContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<BugType> BugTypes { get; set; }

        public DbSet<BugStatus> BugStatuses { get; set; }

        public DbSet<Bug> Bugs { get; set; }

        public DbSet<BugsAuditRecord> BugsAudit { get; set; }
    }
}