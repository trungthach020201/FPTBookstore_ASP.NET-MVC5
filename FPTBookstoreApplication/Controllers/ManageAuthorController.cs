using FPTBookstoreApplication.Data_base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTBookstoreApplication.Controllers
{
    public class ManageAuthorController : Controller
    {
        // GET: ManageAuthor
        private MyApplicationDbContext db = new MyApplicationDbContext();
        public ActionResult Index()
        {
            var author = db.Authors.ToList();
            return View(author);
        }
    }
}