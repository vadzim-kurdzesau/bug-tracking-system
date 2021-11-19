using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BugTrackingSystem.Demo;
using BugTrackingSystem.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BugTrackingSystem.Tests
{
    [TestFixture]
    public class ProjectsRepositoryTests
    {
        private readonly BugTrackingSystemContext context;
        private readonly ProjectsRepository projects;

        public static IEnumerable<TestCaseData> TestProjects
        {
            get
            {
                yield return new TestCaseData(new Project()
                    {Id = 1, Name = "Bug Tracking System", StartDate = new DateTime(2021, 11, 19)});
                yield return new TestCaseData(new Project()
                    {Id = 2, Name = "Electronic Library", StartDate = new DateTime(2021, 11, 12)});
                yield return new TestCaseData(new Project()
                    {Id = 3, Name = "Test Project", StartDate = new DateTime(2021, 11, 1)});
            }
        }

        public ProjectsRepositoryTests()
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            this.context = new BugTrackingSystemContext(configurationManager.ConnectionString);
            this.projects = new ProjectsRepository(this.context);
            ReseedReadersIdentifiers(configurationManager.ConnectionString);
        }

        private static void ReseedReadersIdentifiers(string connectionString)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            new SqlCommand("DBCC CHECKIDENT ('BugTrackingSystem.dbo.projects', RESEED, 0);", sqlConnection).ExecuteNonQuery();
        }

        [Order(0)]
        [TestCaseSource(nameof(TestProjects))]
        public void ProjectsRepositoryTests_AddProject(Project project)
        {
            this.projects.AddProject(project);
            Assert.Pass();
        }

        [Order(1)]
        [TestCaseSource(nameof(TestProjects))]
        public void ProjectsRepositoryTests_GetProject(Project expected)
        {
            Assert.AreEqual(expected.Name, projects.FindProject(expected.Id).Name);
        }

        [Order(2)]
        [TestCaseSource(nameof(TestProjects))]
        public void ProjectsRepositoryTests_UpdateProject(Project project)
        {
            project.StartDate = new DateTime(2021, 11, 15);
            this.projects.UpdateProject(project);
            Assert.AreEqual(new DateTime(2021, 11, 15), projects.FindProject(project.Id).StartDate);
        }

        [Order(3)]
        [TestCaseSource(nameof(TestProjects))]
        public void ProjectsRepositoryTests_DeleteProject(Project expected)
        {
            this.projects.DeleteProject(expected.Id);
            Assert.IsNull(this.context.Projects.FirstOrDefault(p => p.Name == expected.Name));
        }
    }
}