﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.WebApi.Models.Api
{
    public class LogoutUserRequest
    {
        public int SessionId { get; set; }
    }
}