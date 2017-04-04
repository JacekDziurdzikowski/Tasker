namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedToDoListsFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoLists", "ToDoUserId", "dbo.ToDoUsers");
            DropIndex("dbo.ToDoLists", new[] { "ToDoUserId" });
            RenameColumn(table: "dbo.ToDoLists", name: "ToDoUserId", newName: "ToDoUser_ToDoUserId");
            AddColumn("dbo.ToDoLists", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.ToDoLists", "ToDoUser_ToDoUserId", c => c.Int());
            CreateIndex("dbo.ToDoLists", "ToDoUser_ToDoUserId");
            AddForeignKey("dbo.ToDoLists", "ToDoUser_ToDoUserId", "dbo.ToDoUsers", "ToDoUserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoLists", "ToDoUser_ToDoUserId", "dbo.ToDoUsers");
            DropIndex("dbo.ToDoLists", new[] { "ToDoUser_ToDoUserId" });
            AlterColumn("dbo.ToDoLists", "ToDoUser_ToDoUserId", c => c.Int(nullable: false));
            DropColumn("dbo.ToDoLists", "UserId");
            RenameColumn(table: "dbo.ToDoLists", name: "ToDoUser_ToDoUserId", newName: "ToDoUserId");
            CreateIndex("dbo.ToDoLists", "ToDoUserId");
            AddForeignKey("dbo.ToDoLists", "ToDoUserId", "dbo.ToDoUsers", "ToDoUserId", cascadeDelete: true);
        }
    }
}
