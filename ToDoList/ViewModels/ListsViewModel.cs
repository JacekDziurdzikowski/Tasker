using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;

namespace ToDoList.ViewModels
{
    public class ListsViewModel : BaseViewModel
    {
        public List<ToDoList.DomainModels.ToDoList> Lists { get; set; }
    }
}