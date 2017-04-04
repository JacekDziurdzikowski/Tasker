using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ToDoList.DomainModels;

namespace ToDoList.DataConnection
{
    public class ToDoListContext : DbContext
    {
        public DbSet<ToDoList.DomainModels.ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoTask> ToDoTasks { get; set; }
        public DbSet<ToDoUser> ToDoUsers { get; set; }
    }
}