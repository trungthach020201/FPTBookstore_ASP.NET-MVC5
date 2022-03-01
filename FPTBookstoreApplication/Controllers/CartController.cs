using FPTBookstoreApplication.Data_base;
using FPTBookstoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTBookstoreApplication.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        MyApplicationDbContext db = new MyApplicationDbContext();
        public ActionResult Index()
        {
            if ( Session["UserName"] != null)
            {
                return View((List<BookCart>)Session["cart"]);
            }
            else
            {
                return RedirectToAction("Log_in", "Account");
            }

        }

        public ActionResult Add(BookCart book)
        {
            if (Session["UserName"] != null)
            {
                if (Session["cart"] == null)
                {
                    List<BookCart> li = new List<BookCart>();
                    book.quantity1 = 1;
                    li.Add(book);
                    Session["cart"] = li;
                    ViewBag.cart = li.Count();
                    Session["count"] = 1;
                }
                else
                {
                    List<BookCart> li = (List<BookCart>)Session["cart"];
                    book.quantity1 = 1;
                    li.Add(book);
                    Session["cart"] = li;
                    ViewBag.cart = li.Count();
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                }
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return RedirectToAction("Log_in", "Account");
            }
        }

        public ActionResult DeleteItem(BookCart item)
        {
            List<BookCart> li = (List<BookCart>)Session["cart"];
            li.RemoveAll(x => x.BookName == item.BookName);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult MakeOrder(int sum)
        {
            if (Session["UserName"] != null)
            {
                int Sum = sum;
                string username = Session["UserName"].ToString();
                var user = db.Accounts.Where(x => x.UserName.Equals(username)).FirstOrDefault();
                ViewBag.sum = sum+",00$";
                return View(user);
      
            }
            else
            {
                return RedirectToAction("Log_in", "Account");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeOrder(Order oder)
        {
            if (Session["UserName"] != null)
            {
                return HttpNotFound();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var
                }
                return View();
            }
        }
    }
}