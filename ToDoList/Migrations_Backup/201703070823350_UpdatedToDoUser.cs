namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedToDoUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ToDoUsers", "FirstName", c => c.String());
            AddColumn("dbo.ToDoUsers", "LastName", c => c.String());
            AddColumn("dbo.ToDoUsers", "email", c => c.String());
            AddColumn("dbo.ToDoUsers", "Password", c => c.String());
            DropColumn("dbo.ToDoUsers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ToDoUsers", "Name", c => c.String());
            DropColumn("dbo.ToDoUsers", "Password");
            DropColumn("dbo.ToDoUsers", "email");
            DropColumn("dbo.ToDoUsers", "LastName");
            DropColumn("dbo.ToDoUsers", "FirstName");
        }
    }
}
