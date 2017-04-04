using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;
using ToDoList.ViewModels;
using ToDoList.Buissnes;
using ToDoList.Buissnes.Interfaces;
using ToDoList.DomainModels;



namespace ToDoList.Controllers
{
    public class AuthController : Controller
    {

        private IAuthManager _authManager;
        private ISessionManager _sessionManager;


        //public AuthController()
        //{
        //    _authManager = new AuthManager();
        //    _sessionManager = new SessionManager();
        //}

        public AuthController(IAuthManager authManager, ISessionManager sessionManager)
        {
            _authManager = authManager;
            _sessionManager = sessionManager;
        }



        // GET: Auth
        public ActionResult SignUpForm()
        {
            var viewModel = new AuthViewModel();
            return View(viewModel);
        }


        public ActionResult SignInForm()
        {
            var viewModel = new AuthViewModel();
            return View(viewModel);
        }


        public ActionResult SignUpSucceed(AuthViewModel viewModel)
        {
            //trying to add new user
            if (_authManager.AddUserToDb(viewModel.User))
            {
                viewModel.SessionId = _sessionManager.CreateSession(viewModel.User);
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("SignUpFailed");
            }
        }


        public ActionResult SignInSucceed(AuthViewModel viewModel)
        {
            //validating user
            if(_authManager.ValidateUser(viewModel.User))
            {
                //assigning the whole ToDoUser object to viewModel from DB
                viewModel.User = _authManager.GetUser(viewModel.User.email);
                viewModel.SessionId = _sessionManager.CreateSession(viewModel.User);
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("SignInFailed");
            }     
        }


        public ActionResult LogOut(AuthViewModel viewModel)
        {
            _sessionManager.DeleteSession(viewModel.SessionId);

            var baseViewModel = new BaseViewModel();
            return View("LoggedOut", baseViewModel);
        }


        public ActionResult SignUpFailed()
        {
            var viewModel = new BaseViewModel() { User = new ToDoUser() };
            return View(viewModel);
        }

        public ActionResult SignInFailed()
        {
            var viewModel = new BaseViewModel() { User = new ToDoUser() };
            return View(viewModel);
        }
    }
}