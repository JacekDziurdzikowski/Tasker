using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Buissnes.Interfaces;
using ToDoList.DomainModels;
using Microsoft.Practices.Unity;
using ToDoList.Console.Factory;

namespace ToDoList.Console.Constrollers
{
    class BaseController : IBaseController
    {
        private AuthManagerFactory _authFactory = new AuthManagerFactory();
        private SessionManagerFactory _sessFactory = new SessionManagerFactory();
        private ListManagerFactory _listFactory = new ListManagerFactory();
        private TaskManagerFactory _taskFactory = new TaskManagerFactory();

        //public IAuthManager AuthManager;
        public ISessionManager SessionManager;
        public ITaskManager TaskManager;
        public IListManager ListManager;

        //public BaseController(IAuthManager authManager, ISessionManager sessionManager, ITaskManager taskManager, IListManager listManager)
        //{
        //    AuthManager = authManager;
        //    SessionManager = sessionManager;
        //    TaskManager = taskManager;
        //    ListManager = listManager;
        //}

        public void ResolveManagers()
        {
            //AuthManager = _authFactory.InstatiateService();
            SessionManager = _sessFactory.InstatiateService();
            TaskManager = _taskFactory.InstatiateService();
            ListManager = _listFactory.InstatiateService();
        }
    }
}
