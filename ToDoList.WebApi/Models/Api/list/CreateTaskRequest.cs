using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;

namespace ToDoList.WebApi.Models.Api.list
{
    public class CreateTaskRequest
    {
        public ToDoTask Task { get; set; }
        public int SessionId { get; set; }
    }
}