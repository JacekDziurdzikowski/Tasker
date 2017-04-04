namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ToDoLists", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ToDoLists", new[] { "User_Id" });
            DropColumn("dbo.ToDoLists", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToDoLists", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ToDoLists", "User_Id");
            AddForeignKey("dbo.ToDoLists", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
