using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Models
{
    [Table("dbo.bugs")]
    public class Bug
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }

        [Column("bug_type_id")]
        public int BugTypeId { get; set; }

        [Column("bug_status_id")]
        public int BugStatusId { get; set; }

        [Column("project_id")]
        public int ProjectId { get; set; }

        [Column("developer_id")]
        public int? DeveloperId { get; set; }
    }
}
