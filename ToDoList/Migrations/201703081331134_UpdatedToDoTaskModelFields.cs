namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedToDoTaskModelFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoTasks", "ListId", "dbo.ToDoLists");
            DropIndex("dbo.ToDoTasks", new[] { "ListId" });
            RenameColumn(table: "dbo.ToDoTasks", name: "ListId", newName: "ToDoList_ListId");
            AddColumn("dbo.ToDoTasks", "ParentListId", c => c.Int(nullable: false));
            AlterColumn("dbo.ToDoTasks", "ToDoList_ListId", c => c.Int());
            CreateIndex("dbo.ToDoTasks", "ToDoList_ListId");
            AddForeignKey("dbo.ToDoTasks", "ToDoList_ListId", "dbo.ToDoLists", "ListId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoTasks", "ToDoList_ListId", "dbo.ToDoLists");
            DropIndex("dbo.ToDoTasks", new[] { "ToDoList_ListId" });
            AlterColumn("dbo.ToDoTasks", "ToDoList_ListId", c => c.Int(nullable: false));
            DropColumn("dbo.ToDoTasks", "ParentListId");
            RenameColumn(table: "dbo.ToDoTasks", name: "ToDoList_ListId", newName: "ListId");
            CreateIndex("dbo.ToDoTasks", "ListId");
            AddForeignKey("dbo.ToDoTasks", "ListId", "dbo.ToDoLists", "ListId", cascadeDelete: true);
        }
    }
}
