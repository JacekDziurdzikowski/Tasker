using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;

namespace ToDoList.ViewModels
{
    public class TasksViewModel : BaseViewModel
    {
        public List<ToDoTask> Tasks { get; set; }
        //public int ListId { get; set; }
    }
}