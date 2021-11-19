using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Models
{
    [Table("dbo.projects")]
    public class Project
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }
    }
}
