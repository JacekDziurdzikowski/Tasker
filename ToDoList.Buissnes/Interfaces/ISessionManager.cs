using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;

namespace ToDoList.Buissnes.Interfaces
{
    public interface ISessionManager
    {
        ToDoListSession GetSession(int sessionId);

        int CreateSession(ToDoUser user);

        void DeleteSession(int sessionId);

        bool IsActive(int sessionId);
    }
}