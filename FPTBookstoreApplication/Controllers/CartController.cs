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
                    li.Add(book);
                    Session["cart"] = li;
                    ViewBag.cart = li.Count();
                    Session["count"] = 1;
                }
                else
                {
                    List<BookCart> li = (List<BookCart>)Session["cart"];
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
            li.RemoveAll(x => x.BookId == item.BookId);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Index", "Cart");
        }
    }
}