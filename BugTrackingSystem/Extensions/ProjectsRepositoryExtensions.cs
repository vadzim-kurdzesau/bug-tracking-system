using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTrackingSystem.Models;

namespace BugTrackingSystem.Extensions
{
    internal static class ProjectsRepositoryExtensions
    {
        internal static void UpdateProjectTo(this Project projectToUpdate, Project update)
        {
            (projectToUpdate.Name, projectToUpdate.StartDate) = (update.Name, update.StartDate);
        }
    }
}
