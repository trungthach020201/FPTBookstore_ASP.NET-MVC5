using FPTBookstoreApplication.Data_base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTBookstoreApplication.Controllers
{
    public class ManageAccountController : Controller
    {
        private MyApplicationDbContext db = new MyApplicationDbContext();
        // GET: ManageAccount
        public ActionResult Index()
        {
            var acoount = db.Accounts.ToList();

            return View(acoount);
        }
    }
}