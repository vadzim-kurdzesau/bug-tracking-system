namespace BugTrackingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.bugs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 200),
                        update_date = c.DateTime(nullable: false),
                        bug_type_id = c.Int(nullable: false),
                        bug_status_id = c.Int(nullable: false),
                        project_id = c.Int(nullable: false),
                        developer_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.bug_statuses", t => t.bug_status_id, cascadeDelete: true)
                .ForeignKey("dbo.bug_types", t => t.bug_type_id, cascadeDelete: true)
                .ForeignKey("dbo.developers", t => t.developer_id)
                .ForeignKey("dbo.projects", t => t.project_id, cascadeDelete: true)
                .Index(t => t.bug_type_id)
                .Index(t => t.bug_status_id)
                .Index(t => t.project_id)
                .Index(t => t.developer_id);
            
            CreateTable(
                "dbo.bug_statuses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status = c.String(maxLength: 20),
                        description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.bug_types",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.String(maxLength: 20),
                        description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.developers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        first_name = c.String(maxLength: 30),
                        last_name = c.String(maxLength: 30),
                        email = c.String(maxLength: 320, unicode: false),
                        phone = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.projects",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 30, unicode: false),
                        start_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.bugs_audit",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        bug_id = c.Int(nullable: false),
                        description = c.String(maxLength: 200),
                        update_date = c.DateTime(nullable: false),
                        bug_type_id = c.Int(nullable: false),
                        bug_status_id = c.Int(nullable: false),
                        project_id = c.Int(nullable: false),
                        developer_id = c.Int(),
                        developer_message = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.bug_statuses", t => t.bug_status_id, cascadeDelete: true)
                .ForeignKey("dbo.bug_types", t => t.bug_type_id, cascadeDelete: true)
                .ForeignKey("dbo.developers", t => t.developer_id)
                .ForeignKey("dbo.projects", t => t.project_id, cascadeDelete: true)
                .Index(t => t.bug_type_id)
                .Index(t => t.bug_status_id)
                .Index(t => t.project_id)
                .Index(t => t.developer_id);
            
            CreateTable(
                "dbo.ProjectDevelopers",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        Developer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.Developer_Id })
                .ForeignKey("dbo.projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.developers", t => t.Developer_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.Developer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.bugs_audit", "project_id", "dbo.projects");
            DropForeignKey("dbo.bugs_audit", "developer_id", "dbo.developers");
            DropForeignKey("dbo.bugs_audit", "bug_type_id", "dbo.bug_types");
            DropForeignKey("dbo.bugs_audit", "bug_status_id", "dbo.bug_statuses");
            DropForeignKey("dbo.ProjectDevelopers", "Developer_Id", "dbo.developers");
            DropForeignKey("dbo.ProjectDevelopers", "Project_Id", "dbo.projects");
            DropForeignKey("dbo.bugs", "project_id", "dbo.projects");
            DropForeignKey("dbo.bugs", "developer_id", "dbo.developers");
            DropForeignKey("dbo.bugs", "bug_type_id", "dbo.bug_types");
            DropForeignKey("dbo.bugs", "bug_status_id", "dbo.bug_statuses");
            DropIndex("dbo.ProjectDevelopers", new[] { "Developer_Id" });
            DropIndex("dbo.ProjectDevelopers", new[] { "Project_Id" });
            DropIndex("dbo.bugs_audit", new[] { "developer_id" });
            DropIndex("dbo.bugs_audit", new[] { "project_id" });
            DropIndex("dbo.bugs_audit", new[] { "bug_status_id" });
            DropIndex("dbo.bugs_audit", new[] { "bug_type_id" });
            DropIndex("dbo.bugs", new[] { "developer_id" });
            DropIndex("dbo.bugs", new[] { "project_id" });
            DropIndex("dbo.bugs", new[] { "bug_status_id" });
            DropIndex("dbo.bugs", new[] { "bug_type_id" });
            DropTable("dbo.ProjectDevelopers");
            DropTable("dbo.bugs_audit");
            DropTable("dbo.projects");
            DropTable("dbo.developers");
            DropTable("dbo.bug_types");
            DropTable("dbo.bug_statuses");
            DropTable("dbo.bugs");
        }
    }
}
