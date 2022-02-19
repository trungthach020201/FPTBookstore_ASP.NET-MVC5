using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPTBookstoreApplication.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Img { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string CategoryId { get; set; }
        public string AuthorId  { get; set; }
        public DateTime DateAdd { get; set; }
        public string Description { get; set; }
        public ICollection<Orderdetail> Orderdetails { get; set; }
        public virtual Category Categoies { get; set; }
        public virtual Author Authors { get; set; }
    }
}