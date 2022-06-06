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
                    status = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bug_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bug_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bug_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "developers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    last_name = table.Column<string>(type: "NVARCHAR(30)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR(320)", nullable: false),
                    phone = table.Column<string>(type: "NVARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "VARCHAR(30)", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bugs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bug_type_id = table.Column<int>(type: "int", nullable: false),
                    bug_status_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    developer_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bugs", x => x.id);
                    table.ForeignKey(
                        name: "FK_bugs_bug_statuses_bug_status_id",
                        column: x => x.bug_status_id,
                        principalTable: "bug_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bugs_bug_types_bug_type_id",
                        column: x => x.bug_type_id,
                        principalTable: "bug_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bugs_developers_developer_id",
                        column: x => x.developer_id,
                        principalTable: "developers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_bugs_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bugs_audit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bug_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR(200)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bug_type_id = table.Column<int>(type: "int", nullable: false),
                    bug_status_id = table.Column<int>(type: "int", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    developer_id = table.Column<int>(type: "int", nullable: true),
                    developer_message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bugs_audit", x => x.id);
                    table.ForeignKey(
                        name: "FK_bugs_audit_bug_statuses_bug_status_id",
                        column: x => x.bug_status_id,
                        principalTable: "bug_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bugs_audit_bug_types_bug_type_id",
                        column: x => x.bug_type_id,
                        principalTable: "bug_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bugs_audit_developers_developer_id",
                        column: x => x.developer_id,
                        principalTable: "developers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_bugs_audit_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
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
                        name: "FK_projects_developers_developers_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "developers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_projects_developers_projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bugs_bug_status_id",
                table: "bugs",
                column: "bug_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_bugs_bug_type_id",
                table: "bugs",
                column: "bug_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_bugs_developer_id",
                table: "bugs",
                column: "developer_id");

            migrationBuilder.CreateIndex(
                name: "IX_bugs_project_id",
                table: "bugs",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_bugs_audit_bug_status_id",
                table: "bugs_audit",
                column: "bug_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_bugs_audit_bug_type_id",
                table: "bugs_audit",
                column: "bug_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_bugs_audit_developer_id",
                table: "bugs_audit",
                column: "developer_id");

            migrationBuilder.CreateIndex(
                name: "IX_bugs_audit_project_id",
                table: "bugs_audit",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_projects_developers_ProjectsId",
                table: "projects_developers",
                column: "ProjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bugs");

            migrationBuilder.DropTable(
                name: "bugs_audit");

            migrationBuilder.DropTable(
                name: "projects_developers");

            migrationBuilder.DropTable(
                name: "bug_statuses");

            migrationBuilder.DropTable(
                name: "bug_types");

            migrationBuilder.DropTable(
                name: "developers");

            migrationBuilder.DropTable(
                name: "projects");
        }
    }
}
