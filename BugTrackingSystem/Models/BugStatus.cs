using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Models
{
    [Table("bug_statuses")]
    public class BugStatus
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("status")]
        [MaxLength(20)]
        public string Status { get; set; }

        [Column("description")]
        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<Bug> Bugs { get; set; }
    }
}
