using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JustBuy.Models
{
    public class AppDataContext: IdentityDbContext<AppUser>
    {
        public AppDataContext() :base("AppDataContext")
        {

        }
        public static AppDataContext Create()
        {
            return new AppDataContext();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
    }
}