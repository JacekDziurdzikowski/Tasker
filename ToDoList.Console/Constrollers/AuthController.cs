using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DomainModels;
using ToDoList.Buissnes;

namespace ToDoList.Console.Constrollers
{
    class AuthController : BaseController
    {
        public ToDoUser User { get; set; }
        public AuthManager AuthManager { get; set; }

        public AuthController()
        {
            User = new ToDoUser();
            AuthManager = new AuthManager();
        }

        public void DisplayLoginPage()
        {
            System.Console.WriteLine("You are not logged in, please put your email:");
            User.email = System.Console.ReadLine();
            System.Console.WriteLine("Put your password:");
            User.Password = System.Console.ReadLine();
        }

        public int ValidateUser()
        {
            if (AuthManager.ValidateUser(User))
            {
                User = AuthManager.GetUser(User.email);
                return SessionManager.CreateSession(User);
            }
            else
            {
                return 0;
            }      
        }
    }
}
