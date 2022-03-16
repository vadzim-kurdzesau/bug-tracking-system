using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BugTrackingSystem.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bug_statuses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    description = table.Column<string>(type: "NVARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bug_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbo.bug_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    description = table.Column<string>(type: "NVARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.bug_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbo.developers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    last_name = table.Column<string>(type: "NVARCHAR(30)", nullable: true),
                    email = table.Column<string>(type: "NVARCHAR(320)", nullable: true),
                    phone = table.Column<string>(type: "NVARCHAR(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.developers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbo.projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.projects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dbo.bugs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bug_type_id = table.Column<int>(type: "int", nullable: false),
                    bug_status_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    developer_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.bugs", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbo.bugs_bug_statuses_bug_status_id",
                        column: x => x.bug_status_id,
                        principalTable: "bug_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.bugs_dbo.bug_types_bug_type_id",
                        column: x => x.bug_type_id,
                        principalTable: "dbo.bug_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.bugs_dbo.developers_developer_id",
                        column: x => x.developer_id,
                        principalTable: "dbo.developers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_dbo.bugs_dbo.projects_project_id",
                        column: x => x.project_id,
                        principalTable: "dbo.projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbo.bugs_audit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bug_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR(200)", nullable: true),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bug_type_id = table.Column<int>(type: "int", nullable: false),
                    bug_status_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    developer_id = table.Column<int>(type: "int", nullable: true),
                    developer_message = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.bugs_audit", x => x.id);
                    table.ForeignKey(
                        name: "FK_dbo.bugs_audit_bug_statuses_bug_status_id",
                        column: x => x.bug_status_id,
                        principalTable: "bug_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.bugs_audit_dbo.bug_types_bug_type_id",
                        column: x => x.bug_type_id,
                        principalTable: "dbo.bug_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.bugs_audit_dbo.developers_developer_id",
                        column: x => x.developer_id,
                        principalTable: "dbo.developers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_dbo.bugs_audit_dbo.projects_project_id",
                        column: x => x.project_id,
                        principalTable: "dbo.projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projects_developers",
                columns: table => new
                {
                    DevelopersId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects_developers", x => new { x.DevelopersId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_projects_developers_dbo.developers_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "dbo.developers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projects_developers_dbo.projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "dbo.projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbo.bugs_bug_status_id",
                table: "dbo.bugs",
                column: "bug_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_dbo.bugs_bug_type_id",
                table: "dbo.bugs",
                column: "bug_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_dbo.bugs_developer_id",
                table: "dbo.bugs",
                column: "developer_id");

            migrationBuilder.CreateIndex(
                name: "IX_dbo.bugs_project_id",
                table: "dbo.bugs",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_dbo.bugs_audit_bug_status_id",
                table: "dbo.bugs_audit",
                column: "bug_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_dbo.bugs_audit_bug_type_id",
                table: "dbo.bugs_audit",
                column: "bug_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_dbo.bugs_audit_developer_id",
                table: "dbo.bugs_audit",
                column: "developer_id");

            migrationBuilder.CreateIndex(
                name: "IX_dbo.bugs_audit_project_id",
                table: "dbo.bugs_audit",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_developers_ProjectsId",
                table: "projects_developers",
                column: "ProjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbo.bugs");

            migrationBuilder.DropTable(
                name: "dbo.bugs_audit");

            migrationBuilder.DropTable(
                name: "projects_developers");

            migrationBuilder.DropTable(
                name: "bug_statuses");

            migrationBuilder.DropTable(
                name: "dbo.bug_types");

            migrationBuilder.DropTable(
                name: "dbo.developers");

            migrationBuilder.DropTable(
                name: "dbo.projects");
        }
    }
}
