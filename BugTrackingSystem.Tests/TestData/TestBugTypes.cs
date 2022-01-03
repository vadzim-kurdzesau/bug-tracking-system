using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackingSystem.Models;

namespace BugTrackingSystem.Tests.TestData
{
    internal static class TestBugTypes
    {
        internal static IEnumerable<BugType> GetList()
        {
            yield return new BugType()
            {
                Type = "Critical", 
                Description = "Bug must be fixed as fast as possible."
            };

            yield return new BugType()
            {
                Type = "Error",
                Description = "Bug causes problems during program workflow."
            };

            yield return new BugType()
            {
                Type = "Imprecision", 
                Description = "Bug leads to unpredicted result during program workflow."
            };
        }
    }
}
