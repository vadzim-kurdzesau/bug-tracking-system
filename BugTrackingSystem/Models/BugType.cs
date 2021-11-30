using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Models
{
    [Table("bug_types")]
    public class BugType
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("type", TypeName = "NVARCHAR")]
        [MaxLength(20)]
        public string Type { get; set; }

        [Column("description", TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Bug> Bugs { get; set; }
    }
}
