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

            //consider creation of the generic extension method for ArgumentNullException validation
            bug.Developer = developer ?? throw new ArgumentNullException(nameof(developer));
            return bug;
        }

        public static Bug UnassignDeveloper(this Bug bug)
        {
            ValidateBug(bug);
            bug.Developer = null;
            return bug;
        }

        public static IEnumerable<Bug> GetUnassignedBugs(this Developer developer, BugTrackingSystemContext context)
        {
            ValidateContext(context);

            // var unassignedBugs =   from p
            //                                         in developer.Projects
            //                                       join b in context.Bugs
            //                                         on p.Id equals b.ProjectId
            //                                      where b.DeveloperId is null
            //                                     select b;

            // todo: let's discuss which syntax is preferable 
            var unassignedBugs = developer
                                                .Projects
                                                .SelectMany(p => p.Bugs)
                                                .Where(b => !b.DeveloperId.HasValue)
                                                .ToList();

            foreach (var bug in unassignedBugs)
            {
                // todo: let's discuss why yield?
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

        // todo: discuss: having a mixed styles for methods
        public static Bug SetBugStatusSolved(this Bug bug, BugTrackingSystemContext context)
            => SetBugStatus(bug, context, "Solved");

        public static Bug SetBugStatus(this Bug bug, BugTrackingSystemContext context, string statusName)
        {
            ValidateContextAndBug(context, bug);
            ValidateStatusName(statusName);

            // var status = (  from s 
            //                   in context.BugStatuses 
            //                where s.Status == statusName
            //               select s).First();
            
            var status = context
                            .BugStatuses
                            .First(s => s.Status == statusName);

            bug.BugStatus = status ?? throw new ArgumentException($"There is no such status: {statusName}.");
            bug.UpdateDate = DateTime.Now;
            return bug;
        }

        public static Bug AddMessageToNewRecord(this Bug bug, BugTrackingSystemContext context, string message)
        {
            ValidateContextAndBug(context, bug);
            context.SaveChanges();

            var record = (  from r
                              in context.BugsAudit
                           where r.BugId == bug.Id
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
            bug = bug ?? throw new ArgumentNullException(nameof(bug));
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
