//using System.Linq;
//using BugTrackingSystem.Persistence;
//using BugTrackingSystem.Persistence.Models;
//using BugTrackingSystem.Services;
//using BugTrackingSystem.Tests.Extensions;
//using BugTrackingSystem.Tests.TestData;
//using Microsoft.EntityFrameworkCore;
//using NUnit.Framework;

//namespace BugTrackingSystem.Tests
//{
//    [TestFixture]
//    public class BugTrackingSystemTests
//    {
//        private BugTrackingSystemContext _context;

//        //public BugTrackingSystemTests()
//        //{
//        //    //using var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BugTrackingSystem;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//        //    //connection.Open();

//        //    var option = new DbContextOptionsBuilder<BugTrackingSystemContext>().UseInMemoryDatabase("Test").Options;
//        //    this._context = new BugTrackingSystemContext(option);
//        //}

//        [SetUp]
//        public void SetUp()
//        {
//            //ReseedTables();

//            var option = new DbContextOptionsBuilder<BugTrackingSystemContext>().UseInMemoryDatabase("Test").Options;
//            this._context = new BugTrackingSystemContext(option);

//            try
//            {
//                _context.Projects.AddRange(TestProjects.GetList());
//                _context.SaveChanges();
//                _context.Developers.AddRange(TestDevelopers.GetList().ExtractData<Developer>());
//                _context.SaveChanges();
//                _context.BugStatuses.AddRange(TestBugStatuses.GetList());
//                _context.SaveChanges();
//                _context.BugTypes.AddRange(TestBugTypes.GetList());
//                _context.SaveChanges();
//                _context.Bugs.AddRange(TestBugs.GetList().ExtractData<Bug>());
//                _context.SaveChanges();
//            }
//            finally
//            {
//                _context.Database.CloseConnection();
//            }
//        }

//        //private static void ReseedTables()
//        //{
//        //    ReseedTableIdentifiers("bugs");
//        //    ReseedTableIdentifiers("developers");
//        //    ReseedTableIdentifiers("projects");
//        //    ReseedTableIdentifiers("bug_types");
//        //    ReseedTableIdentifiers("bug_statuses");
//        //}

//        //private static void ReseedTableIdentifiers(string tableName)
//        //{
//        //    using SqlConnection sqlConnection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BugTrackingSystem;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//        //    sqlConnection.Open();

//        //    new SqlCommand($"DBCC CHECKIDENT ('BugTrackingSystem.dbo.{tableName}', RESEED, 0);", sqlConnection).ExecuteNonQuery();
//        //}

//        //[TearDown]
//        //public void TearDown()
//        //{
//        //    var developers = this._context.Developers.ToArray();
//        //    this._context.Developers.RemoveRange(developers);

//        //    var projects = this._context.Projects.ToArray();
//        //    this._context.Projects.RemoveRange(projects);

//        //    var bugs = this._context.Bugs.ToArray();
//        //    this._context.Bugs.RemoveRange(bugs);

//        //    var statuses = this._context.BugStatuses.ToArray();
//        //    this._context.BugStatuses.RemoveRange(statuses);

//        //    var types = this._context.BugTypes.ToArray();
//        //    this._context.BugTypes.RemoveRange(types);

//        //    this._context.SaveChanges();
//        //}

//        [TestCaseSource(typeof(TestDevelopers), nameof(TestDevelopers.GetList))]
//        public void BugsServiceTests_GetUnassignedDevelopers(Developer developer)
//        {
//            // Arrange
//            this._context.Developers.Add(developer);
//            this._context.SaveChanges();

//            // Act
//            var actual = this._context.GetUnassignedDevelopers();

//            // Arrange
//            Assert.IsTrue(actual.Contains(developer));
//        }

//        [Test]
//        public void BugsServiceTests_UpdateBug()
//        {
//            foreach (var bug in TestBugs.GetList().ExtractData<Bug>())
//            {
//                // Arrange
//                bug.Description = "Test";

//                // Act
//                _context.UpdateBug(bug);
//                this._context.SaveChanges();

//                // Assert
//                var actual = this._context.Bugs.FirstOrDefault(b => b.Description == "Test");
//                Assert.NotNull(actual);
//            }
//        }
//    }
//}
