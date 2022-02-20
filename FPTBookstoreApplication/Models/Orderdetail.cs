using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPTBookstoreApplication.Models
{
    public class Orderdetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set;}
        public virtual Book Book { get; set; }
    }
}