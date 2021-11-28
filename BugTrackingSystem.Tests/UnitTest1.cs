using NUnit.Framework;

namespace BugTrackingSystem.Tests
{
    //todo: let's add integration tests using Sqlite InMemory DB, sample connection below, you will need to implement code-first migration first

    // public static CatalogDbContext CreateInMemoryDb()
    // {
    //     var connection = new SqliteConnection("DataSource=:memory:");
    //     connection.Open();
    //
    //     var option = new DbContextOptionsBuilder<CatalogDbContext>().UseSqlite(connection).Options;
    //
    //     var context = new CatalogDbContext(option);
    //     context.Database.EnsureDeleted();
    //     context.Database.EnsureCreated();
    //     return context;
    // }

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}