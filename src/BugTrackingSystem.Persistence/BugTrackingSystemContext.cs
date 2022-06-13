using BugTrackingSystem.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTrackingSystem.Persistence
{
    public class BugTrackingSystemContext : DbContext
    {
        public BugTrackingSystemContext(DbContextOptions<BugTrackingSystemContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Developer> Developers { get; set; }

        public virtual DbSet<BugType> BugTypes { get; set; }

        public virtual DbSet<BugStatus> BugStatuses { get; set; }

        public virtual DbSet<Bug> Bugs { get; set; }

        public virtual DbSet<BugsAuditRecord> BugsAudit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Developers)
                .WithMany(d => d.Projects)
                .UsingEntity("projects_developers");
        }
    }
}
