using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPTBookstoreApplication.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; }
        public string AddressDilivery { get; set; }

        public virtual Account Accounts { get; set; }
        public ICollection<Orderdetail> Orderdetails { get; set; } 
    }
}