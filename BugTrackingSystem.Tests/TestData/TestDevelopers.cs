using System.Collections.Generic;
using System.Linq;
using Bogus;
using BugTrackingSystem.Models;
using NUnit.Framework;

namespace BugTrackingSystem.Tests.TestData
{
    internal static class TestDevelopers
    {
        private static readonly Faker<Developer> Faker;

        static TestDevelopers()
        {
            Faker = new Faker<Developer>()
                    .RuleFor(d => d.Id, f => f.IndexFaker)
                    .RuleFor(d => d.FirstName, f => f.Name.FirstName())
                    .RuleFor(d => d.LastName, f => f.Name.LastName())
                    .RuleFor(d => d.Email, f => f.Internet.Email())
                    .RuleFor(d => d.Phone, f => f.Phone.PhoneNumber("###-##-###-##-##"))
                    .RuleFor(d => d.Projects, f => new List<Project>() { f.PickRandom<Project>(TestProjects.GetList())});
        }

        internal static IEnumerable<TestCaseData> GetList()
        {
            return Faker.Generate(100).Select(developer => new TestCaseData(developer));
        }
    }
}
