using System.Collections.Generic;
using BugTrackingSystem.Persistence.Models;
using NUnit.Framework;

namespace BugTrackingSystem.Tests.TestData
{
    internal static class TestDevelopers
    {
        internal static IEnumerable<Developer> GetList()
        {
            yield return new Developer()
            {
                FirstName = "TestUser1",
                LastName = "TestUser1",
                Email = "TestEmail1@mail.com",
                Phone = "123456789",
            };

            yield return new Developer()
            {
                FirstName = "TestUser2",
                LastName = "TestUser2",
                Email = "TestEmail2@mail.com",
                Phone = "123456789",
            };

            yield return new Developer()
            {
                FirstName = "TestUser3",
                LastName = "TestUser3",
                Email = "TestEmail3@mail.com",
                Phone = "123456789",
            };
        }

        //private static readonly Faker<Developer> Faker;

        //static TestDevelopers()
        //{
        //    Faker = new Faker<Developer>()
        //            .RuleFor(d => d.FirstName, f => f.Name.FirstName())
        //            .RuleFor(d => d.LastName, f => f.Name.LastName())
        //            .RuleFor(d => d.Email, f => f.Internet.Email())
        //            .RuleFor(d => d.Phone, f => f.Phone.PhoneNumber("###-##-###-##-##"))
        //            .RuleFor(d => d.Projects, f => new List<Project>() { f.PickRandom<Project>(TestProjects.GetList())});
        //}

        //internal static IEnumerable<TestCaseData> GetList()
        //{
        //    return Faker.Generate(100).Select(developer => new TestCaseData(developer));
        //}
    }
}
