using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;

namespace ToDoList.WebApi.Models.Api.list
{
    public class UpdateListRequest
    {
        public ToDoList.DomainModels.ToDoList List { get; set; }
        public int SessionId { get; set; }
    }
}