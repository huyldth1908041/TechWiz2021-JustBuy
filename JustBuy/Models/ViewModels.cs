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
}