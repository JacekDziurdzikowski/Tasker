using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;

namespace ToDoList.Buissnes.Interfaces
{
    public interface ITaskManager
    {
        List<ToDoTask> GetTasks(int listId);
  
        ToDoTask GetTask(int taskId);

        void AddTaskToDatabase(ToDoTask Task);

        void DeleteTask(int taskId);
    }
}