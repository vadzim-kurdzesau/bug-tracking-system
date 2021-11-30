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
            bug.ValidateNotNull();
            bug.Developer = developer.ValidateNotNull();
            return bug;
        }

        public static Bug UnassignDeveloper(this Bug bug)
        {
            bug.ValidateNotNull();
            bug.Developer = null;
            return bug;
        }

        public static IEnumerable<Bug> GetUnassignedBugs(this Developer developer, BugTrackingSystemContext context)
        {
            context.ValidateNotNull();

            var unassignedBugs = from p
                                                  in developer.Projects
                                                join b in context.Bugs
                                                  on p.Id equals b.ProjectId
                                               where b.DeveloperId is null
                                              select b;

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
            statusName.ValidateNotNull();
            ValidateContextAndBug(context, bug);

             var status = (  from s 
                               in context.BugStatuses 
                            where s.Status == statusName
                           select s).FirstOrDefault();

            bug.BugStatus = status.ValidateNotNull(message: $"There is no such status: {statusName}.");
            bug.UpdateDate = DateTime.Now;
            return bug;
        }

        public static Bug AddMessageToNewRecord(this Bug bug, BugTrackingSystemContext context, string message)
        {
            ValidateContextAndBug(context, bug);
            context.SaveChanges();

            var record = (from r
                            in context.BugsAudit
                          where r.BugId == bug.Id
                          select r).Last();

            record.DeveloperMessage = message.ValidateNotNull();
            return bug;
        }

        private static void ValidateContextAndBug(DbContext context, Bug bug)
        {
            context.ValidateNotNull();
            bug.ValidateNotNull();
        }

        private static void ValidateBugs(Bug bug, Bug update)
        {
            bug.ValidateNotNull();
            update.ValidateNotNull();
        }
    }
}
