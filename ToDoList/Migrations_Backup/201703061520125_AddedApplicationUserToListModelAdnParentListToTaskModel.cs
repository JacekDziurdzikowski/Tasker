namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedApplicationUserToListModelAdnParentListToTaskModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ToDoTasks", name: "ToDoList_ListId", newName: "ParentList_ListId");
            RenameIndex(table: "dbo.ToDoTasks", name: "IX_ToDoList_ListId", newName: "IX_ParentList_ListId");
            AddColumn("dbo.ToDoLists", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ToDoLists", "User_Id");
            AddForeignKey("dbo.ToDoLists", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoLists", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ToDoLists", new[] { "User_Id" });
            DropColumn("dbo.ToDoLists", "User_Id");
            RenameIndex(table: "dbo.ToDoTasks", name: "IX_ParentList_ListId", newName: "IX_ToDoList_ListId");
            RenameColumn(table: "dbo.ToDoTasks", name: "ParentList_ListId", newName: "ToDoList_ListId");
        }
    }
}
