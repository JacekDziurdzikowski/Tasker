using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.WebApi.Models.Api.list
{
    public class CreateListRequest
    {
        public int SessionId { get; set; }
        public string ListName { get; set; }
    }
}