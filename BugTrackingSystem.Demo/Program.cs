using System;
using System.Linq;
using BugTrackingSystem.Models;

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
