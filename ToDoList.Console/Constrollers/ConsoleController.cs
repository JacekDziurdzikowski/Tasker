using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Buissnes;

namespace ToDoList.Console.Constrollers
{
    class ConsoleController : BaseController
    {
        private AuthController _authController = new AuthController();
        private ListController _listController = new ListController();
        private int _sessionId;
        public void MainMenu()
        {

            if (_sessionId != 0)
            {
                foreach(var list in ListManager.GetLists(_sessionId))
                {
                    System.Console.WriteLine(list.ListName);
                }
            }
            else
            {
                DisplayLogo();
                _authController.DisplayLoginPage();
                _sessionId = _authController.ValidateUser();
                MainMenu();
            }
        }


        public void DisplayLogo()
        {
            System.Console.WriteLine(@"
   _______      _____          _      _     _          
  |__   __|    |  __ \        | |    (_)   | |         
     | | ___   | |  | | ___   | |     _ ___| |_        
     | |/ _ \  | |  | |/ _ \  | |    | / __| __|       
     | | (_) | | |__| | (_) | | |____| \__ \ |_        
     |_|\___/  |_____/ \___/  |______|_|___/\__|       
                       _ _           _   _             
     /\               | (_)         | | (_)            
    /  \   _ __  _ __ | |_  ___ __ _| |_ _  ___  _ __  
   / /\ \ | '_ \| '_ \| | |/ __/ _` | __| |/ _ \| '_ \ 
  / ____ \| |_) | |_) | | | (_| (_| | |_| | (_) | | | |
 /_/    \_\ .__/| .__/|_|_|\___\__,_|\__|_|\___/|_| |_|
          | |   | |                                    
          |_|   |_|                                    
                                                        ");
        }
    
        
    }
}
