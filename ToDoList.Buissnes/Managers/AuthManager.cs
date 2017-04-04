using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DataConnection;
using ToDoList.DomainModels;
using ToDoList.Buissnes.Interfaces;

namespace ToDoList.Buissnes
{
    public class AuthManager : IAuthManager
    {
        private ToDoListContext _database;

        public AuthManager()
        {
            using (_database)
            {
                _database = new ToDoListContext();
            }
        }

        public bool AddUserToDb(ToDoUser user)
        {
            //adding user and checking if already that email exists
            if (_database.ToDoUsers.SingleOrDefault(t => t.email == user.email) == null)
            {
                _database.ToDoUsers.Add(user);
                _database.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateUser(ToDoUser user)
        {
            var userCheck = _database.ToDoUsers.SingleOrDefault(t => t.email == user.email);
            if (userCheck != null && userCheck.Password == user.Password)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public ToDoUser GetUser(string email)
        {
            return _database.ToDoUsers.SingleOrDefault(t => t.email == email);
        }

        public bool DeleteUser(ToDoUser user)
        {
            return false;
        }
    
    }
}