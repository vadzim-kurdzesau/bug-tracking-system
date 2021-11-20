using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BugTrackingSystem.Models;

namespace BugTrackingSystem.Services
{
    public static class BugsService
    {
        public static Bug AssignDeveloper(this Bug bug, Developer developer)
        {
            ValidateBug(bug);

            bug.Developer = developer ?? throw new ArgumentNullException(nameof(developer));
            return bug;
        }

        public static Bug UnassignDeveloper(this Bug bug)
        {
            ValidateBug(bug);
            bug.Developer = null;
            return bug;
        }

        public static IEnumerable<Bug> GetAvailableUnassignedBugsForDeveloper(this Developer developer,
            BugTrackingSystemContext context)
        {
            ValidateContext(context);

            var unassignedBugs = from b
                                               in context.Bugs
                                               where b.Project.Id == developer.Id
                                               && b.Developer == null
                                               select b;

            foreach (var bug in unassignedBugs)
            {
                yield return bug;
            }
        }

        public static IEnumerable<Bug> GetUnassignedBugs(this BugTrackingSystemContext context)
        {
            ValidateContext(context);

            var unassignedBugs = from   b
                                               in     context.Bugs 
                                               where  b.Developer == null 
                                               select b;

            foreach (var bug in unassignedBugs)
            {
                yield return bug;
            }
        }

        public static Bug UpdateBug(this Bug bug, Bug update)
        {
            ValidateBugs(bug, update);

            bug = update;
            bug.UpdateDate = DateTime.Now;
            return bug;
        }

        public static Bug SetBugStatusSolved(this Bug bug, BugTrackingSystemContext context)
            => SetBugStatus(bug, context, "Solved");

        public static Bug SetBugStatus(this Bug bug, BugTrackingSystemContext context, string statusName)
        {
            ValidateContextAndBug(context, bug);
            ValidateStatusName(statusName);

            var status = (from   s 
                          in     context.BugStatuses 
                          where  s.Status == statusName
                          select s).First();

            bug.BugStatus = status ?? throw new ArgumentException($"There is no such status: {statusName}.");
            bug.UpdateDate = DateTime.Now;
            return bug;
        }

        public static Bug AddMessageToNewRecord(this Bug bug, BugTrackingSystemContext context, string message)
        {
            ValidateContextAndBug(context, bug);
            context.SaveChanges();

            var record = (from   r
                          in     context.BugsAudit
                          where  r.BugId == bug.Id
                          select r).Last();

            record.DeveloperMessage = message;
            return bug;
        }

        private static void ValidateContextAndBug(DbContext context, Bug bug)
        {
            ValidateContext(context);
            ValidateBug(bug);
        }

        private static void ValidateBug(Bug bug)
        {
            if (bug is null)
            {
                throw new ArgumentNullException(nameof(bug));
            }
        }

        private static void ValidateBugs(Bug bug, Bug update)
        {
            ValidateBug(bug);
            ValidateBug(update);
        }

        private static void ValidateContext(DbContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
        }

        private static void ValidateStatusName(string statusName)
        {
            if (string.IsNullOrWhiteSpace(statusName))
            {
                throw new ArgumentNullException(statusName, "Status name is null, empty or a whitespace.");
            }
        }
    }
}
