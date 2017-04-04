using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;

namespace ToDoList.WebApi.Models.Api
{
    public class RegisterUserResponse
    {
        public ToDoUser ToDoUser { get; set; }
        public int SessionId { get; set; }
    }
}