using FPTBookstoreApplication.Data_base;
using FPTBookstoreApplication.Models;
using System;
using System.IO;
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
            if (Session["UserName"] == "Admin" && Session["UserName"] != null)
            {
                var books = db.Books.ToList();
                return View(books);
            }
            else
            {
                return RedirectToAction("Log_in", "Account");
            }

        }

        public ActionResult AddBook()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(HttpPostedFileBase Img ,Book book)
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");

            if (true)
            {
                var check = db.Books.FirstOrDefault(x => x.BookName.Equals(book.BookName));
                if ( check == null && Img != null && Img.ContentLength>0)
                {
                    string pic= Path.GetFileName(Img.FileName);
                    string path = Path.Combine(Server.MapPath("~/Assets/images/img-Books"), pic);
                    Img.SaveAs(path);
                    book.Img= pic;
                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index", "ManageBook");
                }
                else
                {
                    ViewBag.Error = "This Book is already exist";
                    return View();
                }
            }

            return View("AddBook");
        }
    

        public ActionResult EditBook(int id)
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook([Bind(Include = "BookId,BookName,Img,Quantity,Price,CategoryId,AuthorId,Description")] Book book)
        {
            Book tmp = db.Books.ToList().Find(x => x.BookId == book.BookId); //find the customer in a list have the same ID with the ID input
            if (tmp != null)  //if find out the customer
            {
                tmp.BookName = book.BookName;
                tmp.Description = book.Description;
                tmp.Img= book.Img;
                tmp.Price=book.Price;
                tmp.Quantity=book.Quantity;
                tmp.AuthorId=book.AuthorId;
                tmp.CategoryId=book.CategoryId;
            }
            db.SaveChanges();
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorName");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return RedirectToAction("Index", "ManageBook");
        }

        public ActionResult DeleteBook(int id)
        {
            Book tmp = db.Books.ToList().Find(x => x.BookId == id);
            if (tmp != null)
            {
                db.Books.Remove(tmp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        

    }


}