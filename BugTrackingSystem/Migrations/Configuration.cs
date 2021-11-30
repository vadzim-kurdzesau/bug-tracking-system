using BugTrackingSystem.Models;

namespace BugTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTrackingSystem.BugTrackingSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BugTrackingSystem.BugTrackingSystemContext context)
        {
            context.BugStatuses.AddOrUpdate(
                new BugStatus() { Id = 1, Status = "Opened", Description = "Bug currently has no assigned developer to be handled." },
                new BugStatus() { Id = 2, Status = "In Process", Description = "Bug is being handled by assigned developer." },
                new BugStatus() { Id = 3, Status = "Solved", Description = "Bug was fixed and its issue awaits to be closed." },
                new BugStatus() { Id = 4, Status = "Closed", Description = "Bug's issue was closed." });

            context.BugTypes.AddOrUpdate(
                new BugType() { Id = 1, Type = "Critical", Description = "Bug must be fixed as fast as possible." },
                new BugType() { Id = 2, Type = "Error", Description = "Bug causes problems during program workflow." },
                new BugType() { Id = 3, Type = "Imprecision", Description = "Bug leads to unpredicted result during program workflow." });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
