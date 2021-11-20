using System;
using System.Data.Entity;
using BugTrackingSystem.Models;

namespace BugTrackingSystem.Services
{
    public static class DevelopersService
    {
        public static DbContext AddDeveloper(this BugTrackingSystemContext context, Developer developer)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Developers.Add(developer ?? throw new ArgumentNullException(nameof(developer)));
            return context;
        }
    }
}
