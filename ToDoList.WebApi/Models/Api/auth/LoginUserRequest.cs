using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.WebApi.Models.Api
{
    public class LoginUserRequest
    {
        public string email { get; set; }
        public string Password { get; set; }
    }
}