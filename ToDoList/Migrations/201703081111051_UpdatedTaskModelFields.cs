namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTaskModelFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoTasks", "ToDoList_ListId", "dbo.ToDoLists");
            DropIndex("dbo.ToDoTasks", new[] { "ToDoList_ListId" });
            RenameColumn(table: "dbo.ToDoTasks", name: "ToDoList_ListId", newName: "ListId");
            AlterColumn("dbo.ToDoTasks", "ListId", c => c.Int(nullable: false));
            CreateIndex("dbo.ToDoTasks", "ListId");
            AddForeignKey("dbo.ToDoTasks", "ListId", "dbo.ToDoLists", "ListId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoTasks", "ListId", "dbo.ToDoLists");
            DropIndex("dbo.ToDoTasks", new[] { "ListId" });
            AlterColumn("dbo.ToDoTasks", "ListId", c => c.Int());
            RenameColumn(table: "dbo.ToDoTasks", name: "ListId", newName: "ToDoList_ListId");
            CreateIndex("dbo.ToDoTasks", "ToDoList_ListId");
            AddForeignKey("dbo.ToDoTasks", "ToDoList_ListId", "dbo.ToDoLists", "ListId");
        }
    }
}
