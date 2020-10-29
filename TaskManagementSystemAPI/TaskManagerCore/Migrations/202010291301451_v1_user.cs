namespace TaskManagerCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1_user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        City = c.String(),
                        ContactNumber = c.Long(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LoginCredentials",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TaskName = c.String(),
                        Description = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        Status = c.String(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SubTasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SubTaskName = c.String(),
                        Description = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        Status = c.String(),
                        Task_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "User_Id", "dbo.Users");
            DropForeignKey("dbo.SubTasks", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.LoginCredentials", "Id", "dbo.Users");
            DropIndex("dbo.SubTasks", new[] { "Task_Id" });
            DropIndex("dbo.Tasks", new[] { "User_Id" });
            DropIndex("dbo.LoginCredentials", new[] { "Id" });
            DropTable("dbo.SubTasks");
            DropTable("dbo.Tasks");
            DropTable("dbo.LoginCredentials");
            DropTable("dbo.Users");
        }
    }
}
