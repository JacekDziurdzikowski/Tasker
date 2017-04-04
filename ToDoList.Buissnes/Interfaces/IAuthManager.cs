using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.DomainModels;

namespace ToDoList.Buissnes.Interfaces
{
    public interface IAuthManager
    {
        bool AddUserToDb(ToDoUser user);

        bool ValidateUser(ToDoUser user);

        ToDoUser GetUser(string email);

        bool DeleteUser(ToDoUser user);
    }
}