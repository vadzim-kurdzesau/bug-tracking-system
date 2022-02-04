using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Models
{
    [Table("projects")]
    public class Project
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name", TypeName = "VARCHAR")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        public ICollection<Developer> Developers { get; set; }

        public ICollection<Bug> Bugs { get; set; }
    }
}
