using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;
using ToDoList.Buissnes;
using System.Web.Http;

namespace ToDoList.ViewModels
{
    public class BaseViewModel
    {
        public ToDoUser User { get; set; }
        public int SessionId { get; set; }
        public int ListId { get; set; }
        public int TaskId { get; set; }

        public BaseViewModel()
        {
            //SessionManager = new SessionManager();
            User = new ToDoUser();
        }
    }
}