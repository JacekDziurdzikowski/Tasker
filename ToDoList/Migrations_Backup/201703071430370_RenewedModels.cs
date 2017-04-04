namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenewedModels : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ToDoTasks", name: "ParentList_ListId", newName: "ToDoList_ListId");
            RenameIndex(table: "dbo.ToDoTasks", name: "IX_ParentList_ListId", newName: "IX_ToDoList_ListId");
            DropColumn("dbo.ToDoLists", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToDoLists", "UserId", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.ToDoTasks", name: "IX_ToDoList_ListId", newName: "IX_ParentList_ListId");
            RenameColumn(table: "dbo.ToDoTasks", name: "ToDoList_ListId", newName: "ParentList_ListId");
        }
    }
}
