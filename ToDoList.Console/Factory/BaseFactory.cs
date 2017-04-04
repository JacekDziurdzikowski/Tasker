using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DomainModels;
using ToDoList.Buissnes.Interfaces;
using Microsoft.Practices.Unity;
using ToDoList.Buissnes;

namespace ToDoList.Console.Factory
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
