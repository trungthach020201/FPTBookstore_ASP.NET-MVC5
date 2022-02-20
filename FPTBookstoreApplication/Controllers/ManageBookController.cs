using FPTBookstoreApplication.Data_base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTBookstoreApplication.Controllers
{
    public class ManageBookController : Controller
    {
        private MyApplicationDbContext db = new MyApplicationDbContext();
        // GET: ManageBook
        public ActionResult Index()
        {
            var books = db.Books.ToList();
            return View(books);
        }

        public ActionResult AddNew()
        {
            return View();
        }
    }
}