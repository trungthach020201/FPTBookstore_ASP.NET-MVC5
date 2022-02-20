﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPTBookstoreApplication.Models
{
    public class Category
    {
        [Key]

        [Required(ErrorMessage = "Category ID can not be empty")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name can not be empty")]
        public string CategoryName { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}