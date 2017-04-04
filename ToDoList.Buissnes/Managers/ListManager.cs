using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DataConnection;
using ToDoList.DomainModels;
using ToDoList.Buissnes.Interfaces;

namespace ToDoList.Buissnes
{
    public class ListManager : IListManager
    {
        private ISessionManager _sessionManager;
        private ToDoListContext _database;

        public ListManager(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;

            using (_database)
            {
                _database = new ToDoListContext();
            }
        }


        public List<ToDoList.DomainModels.ToDoList> GetLists(int sessionId)
        {
            var Lists = new List<ToDoList.DomainModels.ToDoList>();

            foreach (var list in _database.ToDoLists.ToList())
            {
                if (list.UserId == _sessionManager.GetSession(sessionId).User.ToDoUserId)
                {
                    Lists.Add(list);
                }
            }
                     
            return Lists;
        }


        public void AddListToDatabase(ToDoList.DomainModels.ToDoList list)
        {
            //this happens when editing an existing list
            if (_database.ToDoLists.SingleOrDefault(t => t.ListId == list.ListId) != null)
            {
                var tempList = _database.ToDoLists.SingleOrDefault(t => t.ListId == list.ListId);
                tempList.ListName = list.ListName;
            }
            //this happens when adding brand new list
            else
            {
                _database.ToDoLists.Add(list);
            }
            _database.SaveChanges();
        }


        public void DeleteList(int listId)
        {
            //removing list and all child tasks
            _database.ToDoLists.Remove(_database.ToDoLists.SingleOrDefault(t => t.ListId == listId));
            foreach(var task in _database.ToDoTasks.ToList())
            {
                if(task.ParentListId == listId)
                {
                    _database.ToDoTasks.Remove(task);
                }
            }
            _database.SaveChanges();
        }



    }
}
