using System;

namespace BugTrackingSystem.Models
{
    public class Bug
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime UpdateDate { get; set; }

        public int BugTypeId { get; set; }

        public int BugStatusId { get; set; }

        public int ProjectId { get; set; }

        public int? DeveloperId { get; set; }
    }
}
