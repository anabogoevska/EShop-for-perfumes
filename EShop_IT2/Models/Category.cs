using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShop_IT2.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName{ get; set; }
        public List<Product> Products { get; set; }

    }
}