using System;
using System.Linq;
using BugTrackingSystem.Persistence;
using BugTrackingSystem.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTrackingSystem.Services
{
    public static class DevelopersService
    {
        public static IQueryable<Developer> GetUnassignedDevelopers(this BugTrackingSystemContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var query =   from developer
                            in context.Developers.Include(d => d.Bugs)
                         where developer.Bugs.Count == 0
                        select developer;

            return query;
        }
    }
}
