﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BugTrackingSystem.Models;

namespace BugTrackingSystem.Services
{
    public static class DevelopersService
    {
        public static DbContext AddDeveloper(this BugTrackingSystemContext context, Developer developer)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Developers.Add(developer ?? throw new ArgumentNullException(nameof(developer)));
            return context;
        }

        public static IEnumerable<Developer> GetUnassignedDevelopers(this BugTrackingSystemContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var query = from   developer
                        in     context.Developers.Include(d => d.Bugs)
                        where  developer.Bugs.Count == 0
                        select developer;

            foreach (var developer in query)
            {
                yield return developer;
            }
        }
    }
}
