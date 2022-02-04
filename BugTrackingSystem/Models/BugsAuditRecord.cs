using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrackingSystem.Models
{
    [Table("bugs_audit")]
    public class BugsAuditRecord
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("bug_id")]
        public int BugId { get; set; }

        [Column("description")]
        [MaxLength(200)]
        public string Description { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }

        [Column("bug_type_id")]
        public int BugTypeId { get; set; }

        public BugType BugType { get; set; }

        [Column("bug_status_id")]
        public int BugStatusId { get; set; }

        public BugStatus BugStatus { get; set; }

        [Column("project_id")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [Column("developer_id")]
        public int? DeveloperId { get; set; }

        public Developer Developer { get; set; }

        [Column("developer_message")]
        [MaxLength(100)]
        public string DeveloperMessage { get; set; }
    }
}
