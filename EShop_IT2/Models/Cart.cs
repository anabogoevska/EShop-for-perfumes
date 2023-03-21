using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop_IT2.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public Product Product { get; set; }
        public int  Quantity { get; set; }


        public Cart (Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;


        }
    }
}