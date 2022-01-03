using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Models
{
    [Table("developers")]
    public class Developer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int? Id { get; set; }

        [Column("first_name", TypeName = "NVARCHAR")]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "NVARCHAR")]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Column("email", TypeName = "VARCHAR")]
        [MaxLength(320)]
        public string Email { get; set; }

        [Column("phone", TypeName = "VARCHAR")]
        [MaxLength(20)]
        public string Phone { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Bug> Bugs { get; set; }
    }
}
