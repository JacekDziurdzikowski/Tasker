using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using ToDoList.Buissnes;
using ToDoList.Buissnes.Interfaces;

namespace ToDoList.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ISessionManager, SessionManager>();
            container.RegisterType<ITaskManager, TaskManager>();
            container.RegisterType<IListManager, ListManager>();
            container.RegisterType<IAuthManager, AuthManager>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}