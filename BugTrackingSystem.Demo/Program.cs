using System;
using System.Data.Entity;
using System.Linq;
using BugTrackingSystem.Persistence;

namespace BugTrackingSystem.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager configuration = new ConfigurationManager();

            using BugTrackingSystemContext dataBase = new BugTrackingSystemContext(configuration.ConnectionString);

            dataBase.SaveChanges();
        }
    }
}
