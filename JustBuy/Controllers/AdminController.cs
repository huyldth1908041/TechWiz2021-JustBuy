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
        private static AppDataContext _db;
        public AdminController()
        {
            if (_db == null)
            {
                _db = new AppDataContext();
            }
        }

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
    }
}