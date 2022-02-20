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
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public DateTime DateAdd { get; set; }
        public string Description { get; set; }
        public ICollection<Orderdetail> Orderdetail { get; set; }
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
    }
}