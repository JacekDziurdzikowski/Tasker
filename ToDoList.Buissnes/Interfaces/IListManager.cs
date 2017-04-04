using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Buissnes.Interfaces
{
    public interface IListManager
    {
        List<ToDoList.DomainModels.ToDoList> GetLists(int sessionId);

        void AddListToDatabase(ToDoList.DomainModels.ToDoList list);

        void DeleteList(int listId);
    }
}