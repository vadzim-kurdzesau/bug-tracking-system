using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Models
{
    [Table("projects")]
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int? Id { get; set; }

        [Column("name", TypeName = "VARCHAR")]
        [MaxLength(30)]
        public string Name { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        public virtual ICollection<Developer> Developers { get; set; }

        public virtual ICollection<Bug> Bugs { get; set; }
    }
}
