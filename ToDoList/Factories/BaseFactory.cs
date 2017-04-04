using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using ToDoList.Buissnes;
using ToDoList.Buissnes.Interfaces;

namespace ToDoList.Factories
{
    public abstract class BaseFactory<T>
    {
        internal UnityContainer Container { get; private set; }
        
        public T InstatiateService()
        {
            Container = new UnityContainer();
            RegisterInterfaces();
            return Container.Resolve<T>();
        }

        internal abstract void RegisterInterfaces();      
    }
}