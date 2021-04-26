using JustBuy.IdentityConfig;
using JustBuy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustBuy.Controllers
{
    public class HomeController : Controller
    {
        private static AppDataContext _db;
        public HomeController()
        {
            if (_db == null)
            {
                _db = new AppDataContext();
            }
        }

        public ActionResult Index()
        {
            var listProduct = _db.Products.Where(p => p.Status == Product.ProductStatus.Active).ToList();
            if (listProduct == null || listProduct.Count() < 3)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var listCategory = _db.Categories.Where(c => c.Status == Category.CategoryStatus.Active).ToList();
            var viewModel = new HomePageViewModel
            {
                Categories = listCategory,
                TopFiveNewestProduct = listProduct.OrderBy(p => p.CreatedAt).Take(5).ToList(),
                TwoFeatureProduct = listProduct.Take(2).ToList(),
                TopThreeNewestProducts = listProduct.OrderBy(p => p.CreatedAt).Take(3).ToList(),
            };
            return View(viewModel);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> FeedBack(FeedBack feedBack, string name, string email, string subject, string phone)
        {
            if (email == null || name == null || phone == null || subject == null)
            {
                TempData["FeedBackMsq"] = "Please fill out your feedback form";
                return View();
            }
            if (Request.IsAuthenticated)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;
                var currentUser = await userManager.FindByIdAsync(User.Identity.GetUserId());
                feedBack.Content = feedBack.Content;
                feedBack.Email = currentUser.Email ?? email;
                feedBack.Phone = currentUser.Phone ?? phone;
                feedBack.Name = currentUser.FullName ?? name;
                feedBack.Subject = subject;
                feedBack.UserId = currentUser.Id;
                feedBack.CreatedAt = DateTime.Now;
                feedBack.UpdatedAt = DateTime.Now;
                _db.FeedBacks.Add(feedBack);
                _db.SaveChanges();
                TempData["FeedBackMsq"] = "Thank you! We've received your feedback";
                return RedirectToAction("Contact");
            }
           

            feedBack.Content = feedBack.Content;
            feedBack.Name = name;
            feedBack.Subject = subject;
            feedBack.Phone = phone;
            feedBack.Email = email;
            feedBack.CreatedAt = DateTime.Now;
            feedBack.UpdatedAt = DateTime.Now;
            _db.FeedBacks.Add(feedBack);
            _db.SaveChanges();
            TempData["FeedBackMsq"] = "Thank you! We've received your feedback";
            return RedirectToAction("Contact");

        }
    }
}