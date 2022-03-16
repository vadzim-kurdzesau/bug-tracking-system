using BugTrackingSystem.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BugTrackingSystem.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager configuration = new ConfigurationManager();

            var dbOptions = new DbContextOptionsBuilder<BugTrackingSystemContext>()
                .UseSqlServer(configuration.ConnectionString).Options;

            using BugTrackingSystemContext dataBase = new BugTrackingSystemContext(dbOptions);

            dataBase.SaveChanges();
        }
    }
}
