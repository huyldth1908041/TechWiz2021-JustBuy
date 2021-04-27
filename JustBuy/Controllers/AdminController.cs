using JustBuy.IdentityConfig;
using JustBuy.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JustBuy.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private AppDataContext _db = new AppDataContext();


        // GET: Admin
        public ActionResult Index()
        {
            var viewModel = new DashBoardViewModels
            {
                ListCurrentOrders = _db.Orders.OrderBy(o => o.CreatedAt).Take(5).ToList(),
                TotalCategory = _db.Categories.Count(),
                TotalCustomer = _db.Users.Count(),
                TotalProduct = _db.Products.Count(),
                TotalOrder = _db.Orders.Count()

            };
            return View(viewModel);
        }

        public ActionResult ListProduct()
        {
            var list = _db.Products.ToList();
            return View(list);
        }

        public ActionResult ListOrder()
        {
            var list = _db.Orders.ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult CancelOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var currentOrder = _db.Orders.Find(id);
            if (currentOrder == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //cancel order
            currentOrder.Status = Order.OrderStatus.Canceled;
            _db.SaveChanges();

            return RedirectToAction("ListOrder");
        }
        [HttpPost]
        public ActionResult CompleteOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var currentOrder = _db.Orders.Find(id);
            if (currentOrder == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //cancel order
            currentOrder.Status = Order.OrderStatus.Done;
            _db.SaveChanges();

            return RedirectToAction("ListOrder");
        }
        [HttpPost]
        public ActionResult ToggleProductStatus(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //cancel order
            product.Status = product.Status == Product.ProductStatus.Active ? Product.ProductStatus.DeActive : Product.ProductStatus.Active;
            _db.SaveChanges();

            return RedirectToAction("ListProduct");
        }

        public ActionResult ListAccounts()
        {
            var list = _db.Users.ToList();
            return View(list);
        }

        public ActionResult CreateProduct()
        {
            ViewBag.ListCategory = _db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product model, List<string> Covers)
        {
            //get cover
            //handels img
            //if user dont upload any image use a place holder instead
            if (Covers == null || Covers.Count() == 0)

            {
                //set cover to holder image public key
                model.Images = "No-Image-Placeholder";
            }
            else
            {
                //save cloudinary public id separated by comma 
                var cover = new StringBuilder();
                foreach (var item in Covers)
                {
                    cover.Append(item);
                    cover.Append(",");
                }
                //delete last comma
                cover.Length--;
                //update model
                model.Images = cover.ToString();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.ListCategory = _db.Categories.ToList();

                Debug.WriteLine("Here");
                Debug.WriteLine(model.Description);
                Debug.WriteLine(model.Name);
                Debug.WriteLine(model.Price);
                Debug.WriteLine(model.CategoryId);
                Debug.WriteLine(model.LaunchDate);
                Debug.WriteLine(model.Images);

                return View(model);
            }
            model.CreatedAt = DateTime.Now;
            model.UpdatedAt = DateTime.Now;
            model.Status = Product.ProductStatus.Active;
            _db.Products.Add(model);
            _db.SaveChanges();

            return RedirectToAction("ListProduct");
        }



    }
}