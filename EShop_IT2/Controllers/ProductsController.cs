using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShop_IT2.Models;
using PagedList.Mvc;
using PagedList;

namespace EShop_IT2.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products

        [Authorize]
        public ActionResult ProductPartial(string sortOrder, string searchString, int? category, int? i)
        {

            if (!User.IsInRole("Administrator"))
            {

                ViewBag.i = i;

                    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                    ViewBag.BrandSortParm = sortOrder == "Brand" ? "brand_desc" : "Brand";
                //  var products = db.Products.Include(p => p.Brand).Include(p => p.Category).ToPagedList(i ?? 1,3);
                var products = db.Products.Include(p => p.Brand).Include(p => p.Category);
                    var products2 = from p in products
                                    select p;
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        products2 = products.Where(p => p.ProductName.Contains(searchString)
                        || p.Brand.BrandName.Contains(searchString));
                    }
                    switch (sortOrder)
                    {
                        case "name_desc":
                            products2 = products2.OrderByDescending(p => p.ProductName);
                            break;
                        case "Brand":
                            products2 = products2.OrderBy(p => p.Brand.BrandName);
                            break;
                        case "brand_desc":
                            products2 = products2.OrderByDescending(s => s.Brand.BrandName);
                            break;
                        default:
                            products2 = products2.OrderBy(p => p.ProductName);
                            break;
                    }
                    // if(!User.IsInRole("Administrator"))
                    return View("ProductPartialUser", products2.ToList());
                    //   return RedirectToAction("ProductPartialUser", products2.ToList());
                }


            
            else
            {

                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.BrandSortParm = sortOrder == "Brand" ? "brand_desc" : "Brand";
                var products = db.Products.Include(p => p.Brand).Include(p => p.Category);
                var products2 = from p in products
                                select p;
                if (!String.IsNullOrEmpty(searchString))
                {
                    products2 = products.Where(p => p.ProductName.Contains(searchString)
                    || p.Brand.BrandName.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        products2 = products2.OrderByDescending(p => p.ProductName);
                        break;
                    case "Brand":
                        products2 = products2.OrderBy(p => p.Brand.BrandName);
                        break;
                    case "brand_desc":
                        products2 = products2.OrderByDescending(s => s.Brand.BrandName);
                        break;
                    default:
                        products2 = products2.OrderBy(p => p.ProductName);
                        break;
                }
                // if(!User.IsInRole("Administrator"))
                return View("ProductPartial", products2.ToList());
                //   return RedirectToAction("ProductPartialUser", products2.ToList());
             
            }



        }

        private PartialViewResult PartialViewResult(IOrderedQueryable<Product> productList)
        {
            throw new NotImplementedException();
        }

        // GET: Products/Details/5

        [Route("Products/Details/{id}")]
        public ActionResult Details(int? id)
        {
            if (!User.IsInRole("Administrator"))
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
                return View("Details",product);
            }

            else 
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
                return View("Details1", product);
            }
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,Picture,Description,Price,Quantity,Rating")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("ProductPartial");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,Picture,Description,Price,Quantity,Rating")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductPartial");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ProductPartial");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       // public ActionResult Adtocart(int? Id)
       // {

       //     Product p = db.Products.Where(x => x.ProductID == Id).SingleOrDefault();
       //     return View(p);
       // }

      //  List<ShoppingCart> li = new List<ShoppingCart>();
      //  [HttpPost]
      //  public ActionResult Adtocart(Product pi, string qty, int Id)
      //  {
          //  Product p = db.Products.Where(x => x.ProductID == Id).SingleOrDefault();

          //  ShoppingCart c = new ShoppingCart();
            // c.ProductId = p.ProductID;
            // c.price = p.Price;
            //c.qty = Convert.ToInt32(qty);
          //  c.bill = c.price * c.qty;
            //c.ProductName = p.ProductName;
            //if (TempData["cart"] == null)
            //{ 
              //  li.Add(c);
                //TempData["cart"] = li;

            //}
            //else
            //{
              //  List<ShoppingCart> li2 = TempData["cart"] as List<ShoppingCart>;
                //li2.Add(c);
                //TempData["cart"] = li2;
            //}

            //TempData.Keep();




            //return RedirectToAction("ProductPartial");
        //}

        public ActionResult checkout()
        {
            TempData.Keep();


            return View();
        }


      
    }


    
 }


