using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Persistence.Models
{
    [Table("bug_types")]
    public class BugType
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("type", TypeName = "NVARCHAR(20)")]
        [Required]
        public string Type { get; set; }

        [Column("description", TypeName = "NVARCHAR(100)")]
        [Required]
        public string Description { get; set; }

        public ICollection<Bug> Bugs { get; set; } = new List<Bug>();
    }
}
