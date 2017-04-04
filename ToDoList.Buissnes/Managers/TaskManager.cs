using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;
using ToDoList.DataConnection;
using ToDoList.Buissnes.Interfaces;

namespace ToDoList.Buissnes
{
    public class TaskManager : ITaskManager
    {
        private ISessionManager _sessionManager;
        private ToDoListContext _database;

        public TaskManager(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
            using (_database)
            {
                _database = new ToDoListContext();
            }
        }


        public List<ToDoTask> GetTasks(int listId)
        {
            var Tasks = new List<ToDoTask>();

            foreach (var task in _database.ToDoTasks.ToList())
            {
                if (task.ParentListId == listId)
                {
                    Tasks.Add(task);
                }
            }

            return Tasks;
        }


        public ToDoTask GetTask(int taskId)
        {
            var Task = _database.ToDoTasks.SingleOrDefault(t => t.TaskId == taskId);
            return Task;
        }


        public void AddTaskToDatabase(ToDoTask Task)
        {
            //this happens when editing existing task
            if (_database.ToDoTasks.SingleOrDefault(t => t.TaskId == Task.TaskId) != null)
            {
                var tempTask = _database.ToDoTasks.SingleOrDefault(t => t.TaskId == Task.TaskId);
                tempTask.TaskName = Task.TaskName;
                tempTask.TaskDesc = Task.TaskDesc;
            }
            //this happens when adding brand new task
            else
            {
                _database.ToDoTasks.Add(Task);
            }
            _database.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            _database.ToDoTasks.Remove(_database.ToDoTasks.SingleOrDefault(t => t.TaskId == taskId));
            _database.SaveChanges();
        }
    }
}