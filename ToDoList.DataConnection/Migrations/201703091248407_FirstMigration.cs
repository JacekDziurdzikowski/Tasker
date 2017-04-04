namespace ToDoList.DataConnection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToDoLists",
                c => new
                    {
                        ListId = c.Int(nullable: false, identity: true),
                        ListName = c.String(),
                        UserId = c.Int(nullable: false),
                        ToDoUser_ToDoUserId = c.Int(),
                    })
                .PrimaryKey(t => t.ListId)
                .ForeignKey("dbo.ToDoUsers", t => t.ToDoUser_ToDoUserId)
                .Index(t => t.ToDoUser_ToDoUserId);
            
            CreateTable(
                "dbo.ToDoTasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        TaskDesc = c.String(),
                        ParentListId = c.Int(nullable: false),
                        ToDoList_ListId = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.ToDoLists", t => t.ToDoList_ListId)
                .Index(t => t.ToDoList_ListId);
            
            CreateTable(
                "dbo.ToDoUsers",
                c => new
                    {
                        ToDoUserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ToDoUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoLists", "ToDoUser_ToDoUserId", "dbo.ToDoUsers");
            DropForeignKey("dbo.ToDoTasks", "ToDoList_ListId", "dbo.ToDoLists");
            DropIndex("dbo.ToDoTasks", new[] { "ToDoList_ListId" });
            DropIndex("dbo.ToDoLists", new[] { "ToDoUser_ToDoUserId" });
            DropTable("dbo.ToDoUsers");
            DropTable("dbo.ToDoTasks");
            DropTable("dbo.ToDoLists");
        }
    }
}
