using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Models
{
    [Table("dbo.developers")]
    public class Developer
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        public ICollection<Project> Projects { get; set; }

        public Developer()
            => this.Projects = new List<Project>();
    }
}
