using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustBuy.Models
{
    public class HomePageViewModel
    {
        public List<Product> TopThreeNewestProducts { get; set; }
        public List<Product> TwoFeatureProduct { get; set; }
        public List<Category> Categories { get; set; }

        public List<Product> TopFiveNewestProduct { get; set; }
    }

    public class OrderCompleteViewModel
    {
        public Order Order { get; set; }
        public AppUser AppUser { get; set; }
    }

    public class CheckoutViewModel
    {
        public Order Order { get; set; }
        public AppUser AppUser { get; set; }
    }


    public class DashBoardViewModels
    {
        public List<Order> ListCurrentOrders { get; set; }
        public int TotalCategory { get; set; }
        public int TotalProduct { get; set; }
        public int TotalCustomer { get; set; }
        public int TotalOrder { get; set; }
    }


}