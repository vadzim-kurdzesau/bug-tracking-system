using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Persistence.Models
{
    [Table("dbo.bugs_audit")]
    public class BugsAuditRecord
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("bug_id")]
        public int BugId { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }

        [Column("bug_type_id")]
        public int BugTypeId { get; set; }

        [ForeignKey("BugTypeId")]
        public BugType BugType { get; set; }

        [Column("bug_status_id")]
        public int BugStatusId { get; set; }

        [ForeignKey("BugStatusId")]
        public BugStatus BugStatus { get; set; }

        [Column("project_id")]
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

        [Column("developer_id")]
        public int? DeveloperId { get; set; }

        [ForeignKey("DeveloperId")]
        public Developer Developer { get; set; }

        [Column("developer_message")]
        public string DeveloperMessage { get; set; }
    }
}
