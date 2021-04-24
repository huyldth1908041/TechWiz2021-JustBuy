using JustBuy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustBuy.Controllers
{
    public class ProductController : Controller
    {
        private static AppDataContext _db;
        public ProductController()
        {
            if(_db == null)
            {
                _db = new AppDataContext();
            }
        }
        // GET: Product
        public ActionResult Index()
        {
            
            return View();
        }
    }
}