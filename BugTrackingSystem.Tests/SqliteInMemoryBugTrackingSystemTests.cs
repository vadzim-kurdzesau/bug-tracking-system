using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BugTrackingSystem.Tests
{
    [TestFixture]
    public class SqliteInMemoryBugTrackingSystemTests : BugTrackingSystemTests
    {
        private readonly BugTrackingSystemContext _context;

        public SqliteInMemoryBugTrackingSystemTests()
        {
            _context = CreateInMemoryDb();
        }

        public static BugTrackingSystemContext CreateInMemoryDb()
        {
            using var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<BugTrackingSystemContext>().UseSqlite(connection).Options;

            var context = new BugTrackingSystemContext(option);
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            return context;
        }
    }

    //public class Tests
    //{
    //    //todo: let's add integration tests using Sqlite InMemory DB, sample connection below, you will need to implement code-first migration first

    //    public static CatalogDbContext CreateInMemoryDb()
    //    {
    //        var connection = new SqliteConnection("DataSource=:memory:");
    //        connection.Open();

    //        var option = new DbContextOptionsBuilder<CatalogDbContext>().UseSqlite(connection).Options;

    //        var context = new CatalogDbContext(option);
    //        context.Database.EnsureDeleted();
    //        context.Database.EnsureCreated();
    //        return context;
    //    }

    //    [SetUp]
    //    public void Setup()
    //    {
    //    }

    //    [Test]
    //    public void Test1()
    //    {
    //        Assert.Pass();
    //    }
    //}
}