using JustBuy.IdentityConfig;
using JustBuy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustBuy.Controllers
{
    public class OrderController : Controller
    {
        private static AppDataContext _db;
        public OrderController()
        {
            if (_db == null)
            {
                _db = new AppDataContext();
            }
        }
        // GET: Order
        [Authorize]
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> CreateOrder(int? productId, int? quantity)
        {
            if (productId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //get current user
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;
            var currentUser = await userManager.FindByIdAsync(User.Identity.GetUserId());
            //current product
            var currentProduct = _db.Products.Find(productId);
            //get pending order if exist
            var pendingOrder = currentUser.Orders.Where(order => order.Status == Order.OrderStatus.Pending).FirstOrDefault();
            if (pendingOrder != null)
            {
                //create order detail then add to current order
                //check if the product already exist
                var existedOrderDetail = pendingOrder.OrderDetails.Where(o => o.ProductId == productId).FirstOrDefault();
                var inDbOrder = _db.Orders.Find(pendingOrder.Id);
                if (existedOrderDetail != null)
                {
                    Debug.WriteLine("Exited product");
                    //increase quantity
                    var inDbOrderDetail = _db.OrderDetails.Find(existedOrderDetail.Id);
                    inDbOrderDetail.Quantity += quantity ?? 1;
                    inDbOrderDetail.UpdatedAt = DateTime.Now;
                    //update total 
                    inDbOrder.CalculateTotalPrice();

                }
                else
                {
                    //create new order detail
                    var orderDetail = new OrderDetail
                    {
                        OrderId = pendingOrder.Id,
                        ProductId = currentProduct.Id,
                        Quantity = quantity ?? 1,
                        SalePrice = currentProduct.Price,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    _db.OrderDetails.Add(orderDetail);
                    //update total 
                    inDbOrder.CalculateTotalPrice();

                }
            }
            else
            {
                //create new order then add product to this order
                var newOrder = new Order
                {
                    Status = Order.OrderStatus.Pending,
                    DeliveryDate = DateTime.Now.AddDays(2),
                    UserId = currentUser.Id,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    ShippingFee = 5

                };

                _db.Orders.Add(newOrder);

                var newOrderDetail = new OrderDetail
                {
                    ProductId = currentProduct.Id,
                    Quantity = quantity ?? 1,
                    SalePrice = currentProduct.Price,
                    OrderId = newOrder.Id,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,

                };
                _db.OrderDetails.Add(newOrderDetail);
                _db.SaveChanges();
                newOrder.CalculateTotalPrice();

            }
            _db.SaveChanges();
            return RedirectToAction("ListOrderDetail");
        }

        [Authorize]
        public async System.Threading.Tasks.Task<ActionResult> ListOrderDetail()
        {
            //get current user
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;
            var currentUser = await userManager.FindByIdAsync(User.Identity.GetUserId());
            var order = currentUser.Orders.Where(o => o.Status == Order.OrderStatus.Pending).FirstOrDefault();
            if (order == null)
            {
                ViewBag.Order = new Order()
                {
                    OrderDetails = new List<OrderDetail>()
                };
                return View(new List<OrderDetail>());
            }
            var listOrderDetail = order.OrderDetails.OrderBy(o => o.CreatedAt).ToList();

            ViewBag.Order = order;

            return View(listOrderDetail);
        }
        //for ajax call
        [HttpGet]
        public ActionResult UpdateOrderDetailQuantity(int id, int quantity)
        {
            var currentOrderDetail = _db.OrderDetails.Find(id);
            //update 
            currentOrderDetail.Quantity = quantity;
            _db.SaveChanges();
            //update total price
            var currentOrder = _db.Orders.Find(currentOrderDetail.OrderId);
            currentOrder.CalculateTotalPrice();
            _db.SaveChanges();
            ViewBag.Order = currentOrder;
            return PartialView("_Cart", currentOrder.OrderDetails.OrderBy(o => o.CreatedAt).ToList());
        }
        [HttpGet]
        public ActionResult Checkout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var order = _db.Orders.Find(id);
            if (order == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            ViewBag.User = order.User;
            return View(order);
        }
        [HttpPost]
        public ActionResult Checkout(int? id, string fullName, string email, string phone, string address, int PaymentMethod)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var order = _db.Orders.Find(id);
            var user = order.User;

            if (order == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var inDbUser = userManager.FindById(user.Id);
            //update current user
            inDbUser.FullName = fullName;
            inDbUser.Email = email;
            inDbUser.Phone = phone;
            inDbUser.Address = address;
            userManager.Update(inDbUser);
            //change order status
            order.Status = Order.OrderStatus.Processing;
            order.PaymentMethod = (Order.OrderPaymentMethod)PaymentMethod;
            _db.SaveChanges();
            return RedirectToAction("OrderComplete", new { id = order.Id });
        }

        public ActionResult OrderComplete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            }
            var order = _db.Orders.Find(id);
            if (order == null || order.Status == Order.OrderStatus.Pending)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            }
            var user = order.User;
            var viewModel = new OrderCompleteViewModel
            {
                Order = order,
                AppUser = user
            };
            return View(viewModel);
        }

    }
}