using System;
using BugTrackingSystem.Models;

namespace BugTrackingSystem.Services
{
    public static class BugsService
    {
        public static Bug AssignDeveloper(this Bug bug, Developer developer)
        {
            if (bug is null)
            {
                throw new ArgumentNullException(nameof(bug));
            }

            bug.Developer = developer ?? throw new ArgumentNullException(nameof(developer));
            return bug;
        }
    }
}
