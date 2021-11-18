using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Models
{
    [Table("dbo.projects_developers")]
    public class ProjectsDevelopers
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("developer_id")]
        public int DeveloperId { get; set; }
    }
}
