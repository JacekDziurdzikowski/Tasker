using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.DomainModels
{
    public class ToDoList
    {
        [Key]
        public int ListId { get; set; }
        public string ListName { get; set; }
        public int UserId { get; set; }
        public List<ToDoTask> Tasks { get; set; }
    }
}