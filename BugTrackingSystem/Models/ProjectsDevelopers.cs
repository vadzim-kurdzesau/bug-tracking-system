﻿namespace BugTrackingSystem.Models
{
    public class ProjectsDevelopers
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int DeveloperId { get; set; }
    }
}