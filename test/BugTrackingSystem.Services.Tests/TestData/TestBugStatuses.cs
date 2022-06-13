using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackingSystem.Persistence.Models;
using NUnit.Framework;

namespace BugTrackingSystem.Tests.TestData
{
    internal static class TestBugStatuses
    {
        internal static IEnumerable<BugStatus> GetList()
        {
            yield return new BugStatus()
            {
                Status = "Opened", 
                Description = "Bug currently has no assigned developer to be handled."
            };

            yield return new BugStatus()
            {
                Status = "In Process",
                Description = "Bug is being handled by assigned developer."
            };

            yield return new BugStatus()
            {
                Status = "Solved", 
                Description = "Bug was fixed and its issue awaits to be closed."
            };

            yield return new BugStatus()
            {
                Status = "Closed",
                Description = "Bug's issue was closed."
            };
        }
    }
}
