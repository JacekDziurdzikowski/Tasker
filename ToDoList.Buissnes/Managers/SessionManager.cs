using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;
using System.Collections.Concurrent;
using ToDoList.Buissnes.Interfaces;

namespace ToDoList.Buissnes
{
    public class SessionManager : ISessionManager
    {
        public static Dictionary<int, ToDoListSession> ActiveSessions = new Dictionary<int, ToDoListSession>();


        public ToDoListSession GetSession(int sessionId)
        {
            return ActiveSessions[sessionId];
        }

        public int CreateSession(ToDoUser user)
        {
            var random = new Random();
            var sessionId = random.Next(1000);
            ActiveSessions.Add(sessionId, new ToDoListSession { User = user});
            return sessionId;
        }

        public void DeleteSession(int sessionId)
        {
            ActiveSessions.Remove(sessionId);
        }

        public bool IsActive(int sessionId)
        {
            return (ActiveSessions.ContainsKey(sessionId));
        }
    }
}