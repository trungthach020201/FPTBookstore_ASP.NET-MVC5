using FPTBookstoreApplication.Data_base;
using FPTBookstoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPTBookstoreApplication.Controllers
{
    public class OderController : Controller
    {
        // GET: Oder
        private MyApplicationDbContext db = new MyApplicationDbContext();
        // GET: ManageCategory
        public ActionResult Index()
        {
            if (Session["UserName"] == "Admin" && Session["UserName"] != null)
            {
                var orders = db.Orders.ToList();
                return View(orders);
            }
            else
            {
                return RedirectToAction("Log_in", "Account");
            }
        }

        public ActionResult DeleteOrder(int? id)
        {
            Order tmp = db.Orders.ToList().Find(x => x.OrderId == id);
            if (tmp != null)
            {
                db.Orders.Remove(tmp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }



    }
}