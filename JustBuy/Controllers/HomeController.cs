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

            return View();
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