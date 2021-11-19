using System;
using System.Linq;
using BugTrackingSystem.Extensions;
using BugTrackingSystem.Models;

namespace BugTrackingSystem
{
    public class ProjectsRepository
    {
        private readonly BugTrackingSystemContext context;

        public ProjectsRepository(BugTrackingSystemContext context)
            => this.context = context;

        public void AddProject(Project project)
        {
            this.context.Projects.Add(project);
            this.context.SaveChanges();
        }

        public Project FindProject(int id)
            => this.context.Projects.Find(id);

        public void UpdateProject(Project project)
        {
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            var projectToUpdate = this.context.Projects.Find(project.Id);
            projectToUpdate?.UpdateProjectTo(project);

            this.context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var projectToDelete = this.context.Projects.First(p => p.Id == id);
            this.context.Projects.Remove(projectToDelete);

            this.context.SaveChanges();
        }
    }
}
