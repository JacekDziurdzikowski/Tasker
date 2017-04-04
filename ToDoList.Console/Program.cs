using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Buissnes.Interfaces;
using ToDoList.DomainModels;
using Microsoft.Practices.Unity;
using ToDoList.Buissnes;
using ToDoList.Console.Constrollers;

namespace ToDoList.Console
{
    class Program
    {
        static void Main(string[] args)
        {    
            DataBinder data = new DataBinder();
            ConsoleController console = new ConsoleController();

            console.MainMenu();
            System.Console.ReadLine();
            
        }
    }
}
