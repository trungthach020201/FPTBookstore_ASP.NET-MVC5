using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPTBookstoreApplication.Models
{
    public class BookCart
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public  string Img { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}