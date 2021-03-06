using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPTBookstoreApplication.Models
{
    public class Account
    {
        [Required (ErrorMessage = "FullName can not be empty")]
        public string FullName { get; set; }
        
        [Key]
        [Required(ErrorMessage = "UserName can not be empty")]
        public string UserName { get; set; }
        
        [Required (ErrorMessage = "PassWord can not be empty")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm PassWord can not be empty")]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Compare("Password", ErrorMessage = "Both Password and Confirm Password Must be Same")]
        public string ConfirmPass { get; set; }

        [Required(ErrorMessage = "Phone number can not be empty")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address can not be empty")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email can not be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "This is not an email") ]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$",
        ErrorMessage = "Please Enter Correct Email Address")]
        public string Email   { get; set; }

        [Required]
        public int StatusCode { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}