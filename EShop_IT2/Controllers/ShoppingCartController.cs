using EShop_IT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EShop_IT2.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private string strCart = "Cart";
        // GET: ShoppingCart
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            if (Session[strCart] == null)
            {
                List<Cart> IsCart = new List<Cart>
                {
                    new Cart(db.Products.Find(id),1)
                };
                Session[strCart] = IsCart;

            }

            else
            {
                List<Cart> lscart = (List<Cart>)Session[strCart];
                int check = isExistingCheck(id);
                if (check == -1)
                    lscart.Add(new Cart(db.Products.Find(id), 1));
                else
                    lscart[check].Quantity++;
                Session[strCart] = lscart;
            }

            return View("Index");
        }

        private int isExistingCheck(int? id)
        {
            List<Cart> lscart = (List<Cart>)Session[strCart];
            for(int i=0; i<lscart.Count; i++)
            {
                if (lscart[i].Product.ProductID == id) return i;
            }
            return -1;
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            int check = isExistingCheck(id);
            List<Cart> lscart = (List<Cart>)Session[strCart];
            lscart.RemoveAt(check);
            return View("Index");
        }

     

        public ActionResult UpdateCart(FormCollection frc)
        {
            string[] quantities = frc.GetValues("quantity");
            List<Cart> lstCart = (List<Cart>)Session[strCart];
            for(int i=0; i < lstCart.Count; i++)
            {
                lstCart[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            Session[strCart] = lstCart;
            return View("Index");
        }


        public ActionResult CheckOut(FormCollection frc)
        {
          
            return View("CheckOut");
        }



        public ActionResult ProcessOrder(FormCollection frc)
        {
            List<Cart> lstCart = (List<Cart>)Session[strCart];

            //save the order into Order table
            Order order = new Order
            {
                CustomerName = frc["cusName"],
                CustomerAddress = frc["cusAddress"],
                CustomerEmail = frc["cusEmail"],
                CustomerPhone = frc["cusPhone"],
                OrderDate = DateTime.Now,
                PaymentType = "Cash",
                Status = "Processing"

            };
             db.Orders.Add(order);
             db.SaveChanges();

            //save the order detail into OrderDetail table
            foreach (Cart cart in lstCart) {
                OrderDetails orderDetails = new OrderDetails
                {
                    OrderID = order.OrderID,
                    ProductID = cart.Product.ProductID,
                    Quantity=cart.Quantity,
                    Price=cart.Product.Price
    

                };
                db.OrderDetails.Add(orderDetails);
                db.SaveChanges();

                //remove shopping cart session
                Session.Remove(strCart);
            }
            return View("OrderSuccess");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}