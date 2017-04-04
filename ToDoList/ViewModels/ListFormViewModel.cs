using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;

namespace ToDoList.ViewModels
{
    public class ListFormViewModel : BaseViewModel
    {
        public ToDoList.DomainModels.ToDoList ToDoList { get; set; }
    }
}