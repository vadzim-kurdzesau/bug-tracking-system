﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Persistence.Models
{
    [Table("dbo.developers")]
    public class Developer
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name", TypeName = "NVARCHAR(20)")]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "NVARCHAR(30)")]
        public string LastName { get; set; }

        [Column("email", TypeName = "NVARCHAR(320)")]
        public string Email { get; set; }

        [Column("phone", TypeName = "NVARCHAR(20)")]
        public string Phone { get; set; }

        public ICollection<Project> Projects { get; set; } = new List<Project>();

        public ICollection<Bug> Bugs { get; set; } = new List<Bug>();
    }
}