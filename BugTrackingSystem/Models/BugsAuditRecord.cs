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

        [Column("description", TypeName = "NVARCHAR")]
        [MaxLength(200)]
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

        [Column("developer_message", TypeName = "NVARCHAR")]
        [MaxLength(100)]
        public string DeveloperMessage { get; set; }

        public BugType BugType { get; set; }

        public BugStatus BugStatus { get; set; }

        public Project Project { get; set; }

        public Developer Developer { get; set; }
    }
}
