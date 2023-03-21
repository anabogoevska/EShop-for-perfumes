using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop_IT2.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public string PaymentType { get; set; }
        public string Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }

    }
}