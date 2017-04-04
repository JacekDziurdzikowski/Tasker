using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.DomainModels
{
    public class ToDoUser
    {
        [Key]
        public int ToDoUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ToDoList> Lists { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
    }
}