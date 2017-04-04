using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Controllers;
using ToDoList.Buissnes.Interfaces;
using ToDoList.Buissnes;
using Microsoft.Practices.Unity;

namespace ToDoList.Factories
{
    public class ListControllerFactory : BaseFactory<ListController>
    {
        internal override void RegisterInterfaces()
        {
            Container.RegisterType<ISessionManager, SessionManager>();
        }
    }
}