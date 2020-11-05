namespace TaskManagerCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2_allTableIncludedForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MainTasks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.SubTasks", "Task_Id", "dbo.MainTasks");
            DropForeignKey("dbo.LoginCredentials", "Id", "dbo.Users");
            DropIndex("dbo.MainTasks", new[] { "User_Id" });
            DropIndex("dbo.SubTasks", new[] { "Task_Id" });
            RenameColumn(table: "dbo.MainTasks", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.SubTasks", name: "Task_Id", newName: "MainTaskId");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.MainTasks");
            DropPrimaryKey("dbo.SubTasks");
            AddColumn("dbo.Users", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.MainTasks", "MainTaskId", c => c.Guid(nullable: false));
            AddColumn("dbo.SubTasks", "SubTaskId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.MainTasks", "TaskName", c => c.String(nullable: false));
            AlterColumn("dbo.MainTasks", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.MainTasks", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.MainTasks", "UserId", c => c.Guid(nullable: false));
            AlterColumn("dbo.SubTasks", "SubTaskName", c => c.String(nullable: false));
            AlterColumn("dbo.SubTasks", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.SubTasks", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.SubTasks", "MainTaskId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Users", "UserId");
            AddPrimaryKey("dbo.MainTasks", "MainTaskId");
            AddPrimaryKey("dbo.SubTasks", "SubTaskId");
            CreateIndex("dbo.MainTasks", "UserId");
            CreateIndex("dbo.SubTasks", "MainTaskId");
            AddForeignKey("dbo.MainTasks", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.SubTasks", "MainTaskId", "dbo.MainTasks", "MainTaskId", cascadeDelete: true);
            AddForeignKey("dbo.LoginCredentials", "Id", "dbo.Users", "UserId");
            DropColumn("dbo.Users", "Id");
            DropColumn("dbo.MainTasks", "Id");
            DropColumn("dbo.SubTasks", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubTasks", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.MainTasks", "Id", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "Id", c => c.Guid(nullable: false));
            DropForeignKey("dbo.LoginCredentials", "Id", "dbo.Users");
            DropForeignKey("dbo.SubTasks", "MainTaskId", "dbo.MainTasks");
            DropForeignKey("dbo.MainTasks", "UserId", "dbo.Users");
            DropIndex("dbo.SubTasks", new[] { "MainTaskId" });
            DropIndex("dbo.MainTasks", new[] { "UserId" });
            DropPrimaryKey("dbo.SubTasks");
            DropPrimaryKey("dbo.MainTasks");
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.SubTasks", "MainTaskId", c => c.Guid());
            AlterColumn("dbo.SubTasks", "Status", c => c.String());
            AlterColumn("dbo.SubTasks", "Description", c => c.String());
            AlterColumn("dbo.SubTasks", "SubTaskName", c => c.String());
            AlterColumn("dbo.MainTasks", "UserId", c => c.Guid());
            AlterColumn("dbo.MainTasks", "Status", c => c.String());
            AlterColumn("dbo.MainTasks", "Description", c => c.String());
            AlterColumn("dbo.MainTasks", "TaskName", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "City", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            DropColumn("dbo.SubTasks", "SubTaskId");
            DropColumn("dbo.MainTasks", "MainTaskId");
            DropColumn("dbo.Users", "UserId");
            AddPrimaryKey("dbo.SubTasks", "Id");
            AddPrimaryKey("dbo.MainTasks", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            RenameColumn(table: "dbo.SubTasks", name: "MainTaskId", newName: "Task_Id");
            RenameColumn(table: "dbo.MainTasks", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.SubTasks", "Task_Id");
            CreateIndex("dbo.MainTasks", "User_Id");
            AddForeignKey("dbo.LoginCredentials", "Id", "dbo.Users", "Id");
            AddForeignKey("dbo.SubTasks", "Task_Id", "dbo.MainTasks", "Id");
            AddForeignKey("dbo.MainTasks", "User_Id", "dbo.Users", "Id");
        }
    }
}
