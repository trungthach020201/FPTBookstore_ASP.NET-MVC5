using FPTBookstoreApplication.Data_base;
using FPTBookstoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FPTBookstoreApplication.Controllers
{
    public class AccountController : Controller
    {
        private MyApplicationDbContext db = new MyApplicationDbContext();

        public AccountController()
        {
        }
        // GET: Account
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your Register page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserName,FullName,PassWord,ConfirmPass,PhoneNumber,BirthDay,Address,Email")] Account account)
        {
            if (ModelState.IsValid)
            {
                // select to check the UserName have exist or not 
                var check = db.Accounts.FirstOrDefault(s => s.UserName == account.UserName);   
                if (check == null)
                {
                    account.Password = GetMD5(account.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Accounts.Add(account);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "This UserName is already exists";
                    return View();
                }
            }
            return View();
        }


        public ActionResult Log_in()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Log_in(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(Password);
                var data = db.Accounts.Where(s => s.UserName.Equals(UserName) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session for the customer and driecrt to the index page
                    Session["FullName"] = data.FirstOrDefault().FullName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["UserName"] = data.FirstOrDefault().UserName;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Log_in");
                }
            }
            return View();
        }


        //Logout we claer tghe user session
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Log_in");
        }

        //create a string MD5 to hash the password
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}