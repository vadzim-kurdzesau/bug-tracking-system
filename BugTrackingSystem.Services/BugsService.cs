using System;
using System.Collections.Generic;
using System.Linq;
using BugTrackingSystem.Persistence;
using BugTrackingSystem.Persistence.Models;
using BugTrackingSystem.Services;
using Microsoft.EntityFrameworkCore;

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

            IEnumerable<Bug> unassignedBugs =   from p
                                                  in developer.Projects
                                                join b in context.Bugs
                                                  on p.Id equals b.ProjectId
                                               where b.DeveloperId is null
                                              select b;

            return unassignedBugs.ToList();
        }

        public static Bug UpdateBug(this BugTrackingSystemContext context, Bug update)
        {
            ValidateContextAndBug(context, update);

            var bug = context.Bugs.First(b => b.Id == update.Id);
            bug.UpdateBug(update);
            return bug;
        }

        private static Bug UpdateBug(this Bug bug, Bug update)
        {
            bug.Description = new string(update.Description);
            bug.UpdateDate = DateTime.Now;
            bug.BugTypeId = update.BugTypeId;
            bug.BugStatusId = update.BugStatusId;
            bug.DeveloperId = update.DeveloperId;

            return bug;
        }

        public static Bug SetBugStatusSolved(this Bug bug, BugTrackingSystemContext context)
        {
            return SetBugStatus(bug, context, "Solved");
        }

        public static Bug SetBugStatus(this Bug bug, BugTrackingSystemContext context, string statusName)
        {
            statusName.ValidateNotNull();
            ValidateContextAndBug(context, bug);

            var status =   (from s
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

            var record =   (from r
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
    }
}
