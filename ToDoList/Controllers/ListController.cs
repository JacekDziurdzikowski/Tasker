using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ToDoList.Models;
using ToDoList.DomainModels;
using ToDoList.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ToDoList.Buissnes;
using ToDoList.Buissnes.Interfaces;

namespace ToDoList.Controllers
{
    //[Authorize]
    public class ListController : Controller
    {

        private IListManager _listManager;
        private ITaskManager _taskManager;
        private ISessionManager _sessionManager;



        public ListController(IListManager listManager, ISessionManager sessionManager, ITaskManager taskManager)
        {
            _listManager = listManager;
            _sessionManager = sessionManager;
            _taskManager = taskManager;
        }


        // GET: List
        public ActionResult ListIndex(BaseViewModel baseViewModel)
        {
            var viewModel = new ListsViewModel();
            viewModel.SessionId = baseViewModel.SessionId;

            if (_sessionManager.IsActive(viewModel.SessionId))
            {
                viewModel.Lists = _listManager.GetLists(viewModel.SessionId);
                viewModel.User = _sessionManager.GetSession(viewModel.SessionId).User;
                return View(viewModel);
            }       
            else
            {
                return RedirectToAction("SignInForm", "Auth");
            }

        }


        public ActionResult Tasks(BaseViewModel baseViewModel)
        {
            if (_sessionManager.IsActive(baseViewModel.SessionId))
            {
                var viewModel = new TasksViewModel();

                viewModel.ListId = baseViewModel.ListId;
                viewModel.SessionId = baseViewModel.SessionId;
                viewModel.User = _sessionManager.GetSession(viewModel.SessionId).User;
                viewModel.Tasks = _taskManager.GetTasks(viewModel.ListId);
                
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("SignInForm", "Auth");
            }

        }

        public ActionResult TaskDetails(BaseViewModel baseViewModel)
        {
            if (_sessionManager.IsActive(baseViewModel.SessionId))
            {
                var viewModel = new TaskFormViewModel();

                viewModel.SessionId = baseViewModel.SessionId;
                viewModel.TaskId = baseViewModel.TaskId;
                viewModel.User = _sessionManager.GetSession(baseViewModel.SessionId).User;
                viewModel.ToDoTask = _taskManager.GetTask(baseViewModel.TaskId);   

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("SignInForm", "Auth");
            }

        }

        public ActionResult ListForm(BaseViewModel baseViewModel)
        {
            var viewModel = new ListFormViewModel();
            viewModel.SessionId = baseViewModel.SessionId;


            if (_sessionManager.IsActive(viewModel.SessionId))
            {           
                viewModel.ToDoList = new ToDoList.DomainModels.ToDoList();
                viewModel.ToDoList.UserId = _sessionManager.GetSession(viewModel.SessionId).User.ToDoUserId;
                viewModel.User = _sessionManager.GetSession(viewModel.SessionId).User;
                return View(viewModel);
            }
            else
            {
                viewModel.User = new ToDoUser();
                return RedirectToAction("SignInForm", "Auth", viewModel);
            }

        }

        public ActionResult SaveList(ListFormViewModel model)
        {
            if(_sessionManager.IsActive(model.SessionId))
            {
                var tempList = new ToDoList.DomainModels.ToDoList();
                tempList.ListId = model.ToDoList.ListId;
                tempList.ListName = model.ToDoList.ListName;
                tempList.UserId = model.ToDoList.UserId;

                _listManager.AddListToDatabase(tempList);

                return RedirectToAction("ListIndex", model);
            }
            else
            {
                var viewModel = new ToDoUser();
                return RedirectToAction("SignInForm", "Auth", viewModel);
            }

        }


        public ActionResult TaskForm(BaseViewModel baseViewModel)
        {
            if(_sessionManager.IsActive(baseViewModel.SessionId))
            {
                var viewModel = new TaskFormViewModel();
                viewModel.User = _sessionManager.GetSession(baseViewModel.SessionId).User;
                viewModel.ToDoTask = new ToDoTask();
                viewModel.ToDoTask.TaskId = baseViewModel.TaskId;
                viewModel.SessionId = baseViewModel.SessionId;
                if (viewModel.ToDoTask.TaskId == 0)
                {
                    viewModel.ToDoTask = new ToDoTask();
                    viewModel.ToDoTask.ParentListId = baseViewModel.ListId;
                }
                else
                {
                    viewModel.ToDoTask = _taskManager.GetTask(baseViewModel.TaskId);
                }
                return View(viewModel);
            }
            else
            {
                var viewModel = new ToDoUser();
                return RedirectToAction("SignInForm", "Auth", viewModel);
            }

        }

        public ActionResult SaveTask(TaskFormViewModel model)
        {
            if(_sessionManager.IsActive(model.SessionId))
            {
                var tempTask = new ToDoTask();
                tempTask.TaskId = model.ToDoTask.TaskId;
                tempTask.TaskName = model.ToDoTask.TaskName;
                tempTask.TaskDesc = model.ToDoTask.TaskDesc;
                tempTask.ParentListId = model.ToDoTask.ParentListId;

                _taskManager.AddTaskToDatabase(tempTask);

                model.ListId = model.ToDoTask.ParentListId;
                return RedirectToAction("Tasks", "List", model);
            }
            else
            {
                var viewModel = new ToDoUser();
                return RedirectToAction("SignInForm", "Auth", viewModel);
            }

        }

        public ActionResult DeleteTask(BaseViewModel baseViewModel)
        {
            if(_sessionManager.IsActive(baseViewModel.SessionId))
            {
                _taskManager.DeleteTask(baseViewModel.TaskId);
                return RedirectToAction("Tasks", baseViewModel);
            }
            else
            {
                var viewModel = new ToDoUser();
                return RedirectToAction("SignInForm", "Auth", viewModel);
            }
        }

        public ActionResult DeleteList(BaseViewModel baseViewModel)
        {
            if(_sessionManager.IsActive(baseViewModel.SessionId))
            {
                _listManager.DeleteList(baseViewModel.ListId);
                return RedirectToAction("ListIndex", baseViewModel);
            }
            else
            {
                var viewModel = new ToDoUser();
                return RedirectToAction("SignInForm", "Auth", viewModel);
            }

        }


    }
}