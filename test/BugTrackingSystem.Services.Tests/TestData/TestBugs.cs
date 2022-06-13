using System;
using System.Collections.Generic;
using BugTrackingSystem.Persistence.Models;
using NUnit.Framework;

namespace BugTrackingSystem.Tests.TestData
{
    internal static class TestBugs
    {
        internal static IEnumerable<TestCaseData> GetList()
        {
            yield return new TestCaseData(new Bug()
            {
                Description = "Configuring volume changes screen brightness.",
                UpdateDate = new DateTime(2021, 11, 30),
                BugTypeId = 3,
                BugStatusId = 1,
                ProjectId = 3
            });

            yield return new TestCaseData(new Bug()
            {
                Description = "Unable to close bug after solving.",
                UpdateDate = new DateTime(2021, 11, 17),
                BugTypeId = 2,
                BugStatusId = 1,
                ProjectId = 2
            });

            yield return new TestCaseData(new Bug()
            {
                Description = "Can't re-take same book after returning previous.",
                UpdateDate = new DateTime(2021, 11, 10),
                BugTypeId = 2,
                BugStatusId = 1,
                ProjectId = 1
            });
        }
    }
}
