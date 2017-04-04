using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Web.Mvc;
using ToDoList.Buissnes;
using ToDoList.Buissnes.Interfaces;

namespace ToDoList.Factories
{
    public class ToDoListFactory
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here  
            //This is the important line to edit  
            container.RegisterType<ISessionManager, SessionManager>();
            container.RegisterType<ITaskManager, TaskManager>();
            container.RegisterType<IListManager, ListManager>();
            container.RegisterType<IAuthManager, AuthManager>(); 


            RegisterTypes(container);
            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}