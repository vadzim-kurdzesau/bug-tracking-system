using System;
using System.Collections.Generic;
using BugTrackingSystem.Models;

namespace BugTrackingSystem.Tests.TestData
{
    internal static class TestProjects
    {
        internal static IEnumerable<Project> GetList()
        {
            yield return new Project()
            {
                Id = 1,
                Name = "Platform Runner",
                StartDate = new DateTime(2021, 11, 25)
            };

            yield return new Project()
            {
                Id = 2,
                Name = "Electronic Library",
                StartDate = new DateTime(2021, 11, 15)
            };

            yield return new Project()
            {
                Id = 3,
                Name = "Bug Tracking System",
                StartDate = new DateTime(2021, 11, 7),
            };
        }
    }
}
