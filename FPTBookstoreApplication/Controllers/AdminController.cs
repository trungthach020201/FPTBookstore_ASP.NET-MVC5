using FPTBookstoreApplication.Data_base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FPTBookstoreApplication.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private MyApplicationDbContext db = new MyApplicationDbContext();
        public ActionResult Index()
        {
            if (Session["UserName"] == "Admin" && Session["UserName"] != null )
            {
                return View();
            }
            else
            {
                return RedirectToAction("Log_in","Account");
            }
        }

    }
}