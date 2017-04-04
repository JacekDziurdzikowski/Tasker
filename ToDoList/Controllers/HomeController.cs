using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.ViewModels;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        BaseViewModel baseModel;
        public HomeController()
        {
            baseModel = new BaseViewModel();
        }

        public ActionResult Index()
        {
            return View(baseModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(baseModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(baseModel);
        }
    }
}