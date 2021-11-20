using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Models
{
    [Table("dbo.bug_types")]
    public class BugType
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("description")]
        public string Description { get; set; }

        public ICollection<Bug> Bugs { get; set; }

        public BugType()
            => this.Bugs = new List<Bug>();
    }
}
