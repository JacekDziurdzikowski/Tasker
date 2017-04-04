﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Buissnes.Interfaces;
using Microsoft.Practices.Unity;
using ToDoList.Buissnes;

namespace ToDoList.Console.Factory
{
    public class TaskManagerFactory : BaseFactory<TaskManager>
    {
        internal override void RegisterInterfaces()
        {
            Container.RegisterType<ITaskManager, TaskManager>();
        }
    }
}