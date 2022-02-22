﻿using FPTBookstoreApplication.Data_base;
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
                return RedirectToAction("Log_in");
            }
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your Register page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserName,FullName,Password,ConfirmPass,PhoneNumber,Birthday,Address,Email")] Account account)
        {
            if (ModelState.IsValid)
            {
                var check = db.Accounts.FirstOrDefault(x => x.Email == account.Email);
                if (check == null)
                {
                    account.Password = GetMD5(account.Password);
                    account.ConfirmPass = GetMD5(account.ConfirmPass);
                    account.StatusCode = 0;
                    db.Accounts.Add(account);
                    db.SaveChanges();
                    return RedirectToAction("Log_in");
                }
                else
                {
                    ViewBag.Error = "This Email is already exist";
                    return View();
                }
            }
            return View("Register");
        }


        public ActionResult Log_in()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Log_in(string userName, string Password)
        {
            if (ModelState.IsValid)
            {
                var _password = GetMD5(Password);
                var data = db.Accounts.Where(s => s.UserName.Equals(userName) && s.Password.Equals(_password)).ToList();
                if (data.Count() > 0)
                {
                    if (data.FirstOrDefault().StatusCode == 0)
                    {
                        //add session for the customer and driecrt to the index page
                        Session["UserName"] = data.FirstOrDefault().UserName;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        Session["UserName"] = data.FirstOrDefault().UserName;
                        return RedirectToAction("Index", "Admin");
                    }
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
        public ActionResult Log_out()
        {
            Session["UserName"]= null;//remove session
            return RedirectToAction("Index","Home");
        }

        public ActionResult EditInfor()
        {
           var user = Session["UserName"];
           Account obj = db.Accounts.ToList().Find(x => x.UserName.Equals(user));
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInfor(Account obj)
        {
            Account tmp = db.Accounts.ToList().Find(x => x.UserName == obj.UserName); //find the customer in a list have the same ID with the ID input
            if (tmp != null)  //if find out the customer
            {
                tmp.UserName = obj.UserName;
                tmp.FullName = obj.FullName;
                tmp.Password =  GetMD5(obj.Password);
                tmp.PhoneNumber = obj.PhoneNumber;
                tmp.Email = obj.Email;
                tmp.Birthday = obj.Birthday;
                tmp.Address = obj.Address;
                tmp.ConfirmPass =  GetMD5(obj.ConfirmPass);
                tmp.StatusCode = obj.StatusCode =0;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
