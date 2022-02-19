using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTBookstoreApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Help()
        {
            ViewBag.Message = "Your Help page.";

            return View();
        }
        public ActionResult Cart()
        {
            ViewBag.Message = "Your Cart page.";

            return View();
        }
        public ActionResult BookDetail()
        {
            ViewBag.Message = "Your BookDetail page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your About us page.";

            return View();
        }
    }
}