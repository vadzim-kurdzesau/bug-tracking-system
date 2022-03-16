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

        public DbSet<Project> Projects { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<BugType> BugTypes { get; set; }

        public DbSet<BugStatus> BugStatuses { get; set; }

        public DbSet<Bug> Bugs { get; set; }

        public DbSet<BugsAuditRecord> BugsAudit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            Database.EnsureCreated();
        }

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
