using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTrackingSystem.Persistence.Migrations
{
    public partial class AddTriggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TRIGGER TR_bugs_UPDATE
                                               ON dbo.bugs
                                            AFTER INSERT, UPDATE
                                               AS
                                           INSERT bugs_audit
                                                    (bug_id, description, update_date, bug_type_id, bug_status_id, project_id, developer_id)
                                           SELECT id, description, update_date, bug_type_id, bug_status_id, project_id, developer_id
                                             FROM inserted; ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER TR_bugs_UPDATE");
        }
    }
}
