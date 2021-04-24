using JustBuy.Models;
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
            if(listProduct == null || listProduct.Count() < 3)
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
        [Authorize]
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
    }
}