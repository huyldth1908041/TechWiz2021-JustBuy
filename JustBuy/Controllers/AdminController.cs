using JustBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustBuy.Controllers
{
    public class AdminController : Controller
    {
        private  AppDataContext _db = new AppDataContext();
   

        // GET: Admin
        public ActionResult Index()
        {
            return View();
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
        



    }
}