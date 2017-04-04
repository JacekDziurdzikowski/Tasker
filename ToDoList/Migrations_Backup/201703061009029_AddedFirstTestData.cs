namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFirstTestData : DbMigration
    {
        public override void Up()
        {
            Sql("alter table ToDoLists drop column UserName");
            Sql("insert into ToDoLists(UserId, ListName) values (1, 'FirstToDoList')");
            Sql("insert into ToDoLists(UserId, ListName) values (1, 'SecondToDoList')");
            Sql("insert into ToDoLists(UserId, ListName) values (2, 'FirstToDoList')");
            Sql("insert into ToDoLists(UserId, ListName) values (2, 'SecondToDoList')");
            Sql("insert into ToDoLists(UserId, ListName) values (3, 'FirstToDoList')");
            Sql("insert into ToDoLists(UserId, ListName) values (3, 'FirstToDoList')");

            Sql("insert into ToDoTasks(TaskName, TaskDesc) values ('FirstTask', 'This is FirstTask Description')");
            Sql("insert into ToDoTasks(TaskName, TaskDesc) values ('SecondTask', 'This is SecondTask Description')");
            Sql("insert into ToDoTasks(TaskName, TaskDesc) values ('FirstTask', 'This is FirstTask Description')");
            Sql("insert into ToDoTasks(TaskName, TaskDesc) values ('SecondTask', 'This is SecondTask Description')");
            Sql("insert into ToDoTasks(TaskName, TaskDesc) values ('FirstTask', 'This is FirstTask Description')");
            Sql("insert into ToDoTasks(TaskName, TaskDesc) values ('SecondTask', 'This is SecondTask Description')");

            Sql("insert into ToDoUsers(Name) values ('Jacek')");
            Sql("insert into ToDoUsers(Name) values ('Placek')");
            Sql("insert into ToDoUsers(Name) values ('Na Oleju')");



        }

        public override void Down()
        {
        }
    }
}
