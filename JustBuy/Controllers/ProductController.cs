using JustBuy.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (_db == null)
            {
                _db = new AppDataContext();
            }
        }
        // GET: Product
        public ActionResult Index(int? page)
        {

            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 6;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);



            var list = _db.Products.Where(p => p.Status == Product.ProductStatus.Active).OrderBy(p => p.CreatedAt);
            ViewBag.ListCate = _db.Categories.Where(c => c.Status == Category.CategoryStatus.Active).ToList();
            ViewBag.ToTal = list.Count();
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var product = _db.Products.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }

            ViewBag.Related = product.Category.Products.OrderBy(p =>p.CreatedAt).Take(3).ToList();
            return View(product);
        }

        public ActionResult Filter(int? categoryId, string price, int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;



            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 6;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            //recevied price: $start - $end
            if(price == null || price.Length == 0)
            {
                price = "$10 - $100";
            }
            //get start, end
            String removedDollarSign = price.Replace("$", ""); // "start - end"
            String[] splitted = removedDollarSign.Split('-'); //["start", "end"]

            int start = int.Parse(splitted[0]);
            int end = int.Parse(splitted[1]);
            var listProduct = _db.Products.Where(p => p.Status == Product.ProductStatus.Active);
            IEnumerable<Product> listResult;
            if (categoryId != null && categoryId != 0)
            {
                listResult = listProduct.Where(p => p.CategoryId == categoryId && (p.Price >= start && p.Price <= end)).OrderBy(p => p.CreatedAt);
            }
            else
            {
                listResult = listProduct.Where(p => p.Price >= start && p.Price <= end).OrderBy(p => p.CreatedAt);
            }
            ViewBag.ListCate = _db.Categories.Where(c => c.Status == Category.CategoryStatus.Active).ToList();
            ViewBag.ToTal = listResult.Count();
            ViewBag.CategoryId = categoryId ?? 0; // categoryId == null ? 0 : categoryId
            ViewBag.Price = price;
            ViewBag.Start = start;
            ViewBag.End = end;

            return View(listResult.ToPagedList(pageNumber, pageSize));
        }

        //ajax call only
        public ActionResult Search(string name, int? page)
        {
            if (page == null) page = 1;
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            IEnumerable<Product> result;
            var listProducts = _db.Products.Where(p => p.Status == Product.ProductStatus.Active).ToList();
            Debug.WriteLine(name);
            if(name != null && name.Length != 0)
            {
                result = listProducts.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }
            else
            {
                result = listProducts;
            }
            return PartialView(result.ToPagedList(pageNumber, pageSize));
        }
    }
}