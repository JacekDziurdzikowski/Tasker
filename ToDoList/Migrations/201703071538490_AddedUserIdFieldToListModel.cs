namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIdFieldToListModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoLists", "ToDoUser_ToDoUserId", "dbo.ToDoUsers");
            DropIndex("dbo.ToDoLists", new[] { "ToDoUser_ToDoUserId" });
            RenameColumn(table: "dbo.ToDoLists", name: "ToDoUser_ToDoUserId", newName: "ToDoUserId");
            AlterColumn("dbo.ToDoLists", "ToDoUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ToDoLists", "ToDoUserId");
            AddForeignKey("dbo.ToDoLists", "ToDoUserId", "dbo.ToDoUsers", "ToDoUserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoLists", "ToDoUserId", "dbo.ToDoUsers");
            DropIndex("dbo.ToDoLists", new[] { "ToDoUserId" });
            AlterColumn("dbo.ToDoLists", "ToDoUserId", c => c.Int());
            RenameColumn(table: "dbo.ToDoLists", name: "ToDoUserId", newName: "ToDoUser_ToDoUserId");
            CreateIndex("dbo.ToDoLists", "ToDoUser_ToDoUserId");
            AddForeignKey("dbo.ToDoLists", "ToDoUser_ToDoUserId", "dbo.ToDoUsers", "ToDoUserId");
        }
    }
}
