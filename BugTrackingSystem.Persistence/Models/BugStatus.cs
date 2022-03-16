using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Persistence.Models
{
    [Table("bug_statuses")]
    public class BugStatus
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("status", TypeName = "NVARCHAR(20)")]
        public string Status { get; set; }

        [Column("description", TypeName = "NVARCHAR(100)")]
        public string Description { get; set; }

        public ICollection<Bug> Bugs { get; set; } = new List<Bug>();
    }
}
