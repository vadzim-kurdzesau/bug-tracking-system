using System;
using System.Collections.Generic;
using System.Linq;
using BugTrackingSystem.Models;
using BugTrackingSystem.Services;
using BugTrackingSystem.Tests.TestData;
using NUnit.Framework;

namespace BugTrackingSystem.Tests
{
    [TestFixture]
    internal class BugsServiceTests
    {
        private readonly BugTrackingSystemContext _context;

        public BugsServiceTests()
        {
            this._context = new BugTrackingSystemContext();
        }

        [SetUp]
        public void SetUp()
        {
            _context.Projects.AddRange(TestProjects.GetList());

            this._context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            var developers = this._context.Developers.ToArray();
            this._context.Developers.RemoveRange(developers);

            var projects = this._context.Projects.ToArray();
            this._context.Projects.RemoveRange(projects);

            this._context.SaveChanges();
        }

        [TestCaseSource(typeof(TestDevelopers), nameof(TestDevelopers.GetList))]
        public void BugsServiceTests_GetUnassignedDevelopers(Developer developer)
        {
            // Arrange
            this._context.Developers.Add(developer);
            this._context.SaveChanges();

            // Act
            var actual = this._context.GetUnassignedDevelopers();

            // Arrange
            Assert.IsTrue(actual.Contains(developer));
        }
    }
}
