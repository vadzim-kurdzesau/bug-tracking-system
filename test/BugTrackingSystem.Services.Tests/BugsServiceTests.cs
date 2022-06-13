using System;
using System.Collections.Generic;
using System.Linq;
using BugTrackingSystem.Persistence;
using BugTrackingSystem.Persistence.Models;
using BugTrackingSystem.Tests.Extensions;
using BugTrackingSystem.Tests.TestData;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;

namespace BugTrackingSystem.Services.Tests
{
    [TestFixture]
    public class BugsServiceTests
    {
        private BugTrackingSystemContext _context;
        private Mock<BugTrackingSystemContext> _contextMock;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<BugTrackingSystemContext>()
                .UseInMemoryDatabase("TestDB").Options;
            _contextMock = new Mock<BugTrackingSystemContext>(options);
        }

        [Test]
        public void AssignDeveloper_BugIsNull_ThrowsAnException()
        {
            // Arrange
            Bug bug = null;
            var developer = TestDevelopers.GetList().First();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => bug.AssignDeveloper(developer));
        }

        [Test]
        public void AssignDeveloper_DeveloperIsNull_ThrowsAnException()
        {
            // Arrange
            var bug = TestBugs.GetList().ExtractData<Bug>().First();
            Developer developer = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => bug.AssignDeveloper(developer));
        }

        [Test]
        public void AssignDeveloper_AssignsDeveloper()
        {
            // Arrange
            var developer = TestDevelopers.GetList().First();
            var bug = TestBugs.GetList().ExtractData<Bug>().First(b => b.DeveloperId == null);

            // Act
            bug.AssignDeveloper(developer);

            // Assert
            Assert.NotNull(bug.Developer);
        }

        [Test]
        public void UnassignDeveloper_BugIsNull_ThrowsAnException()
        {
            // Arrange
            Bug bug = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => bug.UnassignDeveloper());
        }

        [Test]
        public void UnassignDeveloper_UnassignsDeveloper()
        {
            // Arrange
            var developer = TestDevelopers.GetList().First();
            var bug = TestBugs.GetList().ExtractData<Bug>().First(b => b.DeveloperId == null);
            bug.Developer = developer;

            // Act
            bug.UnassignDeveloper();

            // Assert
            Assert.Null(bug.Developer);
        }

        [Test]
        public void GetUnassignedBugs_ReturnsUnassignedBugs()
        {
            // Arrange
            const int projectId = 1;

            var bugs = new Bug[]
            {
                new Bug
                {
                    ProjectId = projectId,
                },

                new Bug
                {
                    ProjectId = projectId,
                },

                new Bug
                {
                    ProjectId = 2,
                },
            };

            _contextMock.Setup(c => c.Bugs).ReturnsDbSet(bugs);

            var developer = new Developer
            {
                Projects = new List<Project>
                {
                    new Project { Id = projectId }
                }
            };

            // Act
            var actual = developer.GetUnassignedBugs(_contextMock.Object);

            // Assert
            Assert.AreEqual(bugs.Where(b => b.ProjectId == projectId), actual);
        }

        [Test]
        public void AddMessageToNewRecord_RecordExists_AddsMessageToRecord()
        {
            // Arrange
            const int bugId = 1;
            const string expectedMessage = "Test3";

            var bug = new Bug { Id = bugId };

            var bugAudits = new BugsAuditRecord[]
            {
                new BugsAuditRecord
                {
                    BugId = bugId,
                    DeveloperMessage = "Test1",
                },

                new BugsAuditRecord
                {
                    BugId = bugId,
                    DeveloperMessage = "Test2",
                },

                new BugsAuditRecord
                {
                    BugId = bugId,
                },
            };

            _contextMock.Setup(c => c.BugsAudit).ReturnsDbSet(bugAudits);

            // Act
            bug.AddMessageToNewRecord(_contextMock.Object, expectedMessage);

            // Assert
            Assert.IsTrue(bugAudits.Any(a => a.DeveloperMessage.Equals(expectedMessage)));
        }

        [Test]
        public void AddMessageToNewRecord_NoRecords_ThrowsAnException()
        {
            // Arrange
            const string expectedMessage = "Test1";

            var bug = new Bug { Id = 1 };

            _contextMock.Setup(c => c.BugsAudit).ReturnsDbSet(Array.Empty<BugsAuditRecord>());

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => bug.AddMessageToNewRecord(_contextMock.Object, expectedMessage));
        }
    }
}
