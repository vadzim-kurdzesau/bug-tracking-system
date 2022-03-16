using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Persistence.Models
{
    [Table("dbo.projects")]
    public class Project
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name", TypeName = "VARCHAR(30)")]
        [Required]
        public string Name { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        public ICollection<Developer> Developers { get; set; } = new List<Developer>();

        public ICollection<Bug> Bugs { get; set; } = new List<Bug>();
    }
}
