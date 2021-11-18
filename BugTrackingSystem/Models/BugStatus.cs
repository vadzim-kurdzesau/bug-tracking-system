using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Models
{
    [Table("bug_statuses")]
    public class BugStatus
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
