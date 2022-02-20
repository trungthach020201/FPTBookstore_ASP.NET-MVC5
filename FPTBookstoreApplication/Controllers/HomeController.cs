using FPTBookstoreApplication.Data_base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTBookstoreApplication.Controllers
{
    public class HomeController : Controller
    {
        private MyApplicationDbContext db = new MyApplicationDbContext();
        public ActionResult Index()
        {
            var books = db.Books.ToList();
            return View(books);
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
        public ActionResult BookDetail(int? id)
        {
            var book = db.Books.FirstOrDefault(x => x.BookId == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            else
            {
                var author = db.Authors.FirstOrDefault(x => x.AuthorId==book.AuthorId);
                var category = db.Categories.FirstOrDefault(x => x.CategoryId== book.CategoryId);
                ViewBag.Author = author;
                ViewBag.Category = category;
            }
            return View(book);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your About us page.";

            return View();
        }
    }
}