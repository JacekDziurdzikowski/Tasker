using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;

namespace ToDoList.ViewModels
{
    public class TaskFormViewModel : BaseViewModel
    {
        public ToDoTask ToDoTask { get; set; }
    }
}