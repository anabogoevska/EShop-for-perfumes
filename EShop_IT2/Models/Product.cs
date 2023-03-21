using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShop_IT2.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Quantity { get; set; }
        public int Rating { get; set; }

  
        public Brand Brand { get; set; }


 
        public Category Category { get; set; }


    }
}