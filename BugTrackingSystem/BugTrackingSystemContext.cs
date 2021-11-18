using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackingSystem.Models;

namespace BugTrackingSystem
{
    public class BugTrackingSystemContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<ProjectsDevelopers> ProjectsDevelopers { get; set; }

        public DbSet<BugType> BugTypes { get; set; }

        public DbSet<BugStatus> BugStatuses { get; set; }

        public DbSet<Bug> Bugs { get; set; }

        public DbSet<BugHistoryRecord> BugHistory { get; set; }
    }
}
