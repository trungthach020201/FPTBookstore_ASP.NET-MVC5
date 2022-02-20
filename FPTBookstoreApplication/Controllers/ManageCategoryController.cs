using FPTBookstoreApplication.Data_base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTBookstoreApplication.Controllers
{
    public class ManageCategoryController : Controller
    {
        private MyApplicationDbContext db = new MyApplicationDbContext();
        // GET: ManageCategory
        public ActionResult Index()
        {
            var category = db.Categories.ToList();
            return View(category);
        }
    }
}