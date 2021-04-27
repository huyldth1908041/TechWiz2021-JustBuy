using JustBuy.IdentityConfig;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace JustBuy.Models
{
    public class AppUser : IdentityUser
    {

        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public enum UserStatus
        {
            Active,
            DeActive
        }

        public virtual ICollection<FeedBack> FeedBacks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public string GetFirstRole()
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            var listRole = userManager.GetRolesAsync(this.Id).Result;
            if (listRole == null || listRole.Count() == 0)
            {
                return "Not Set";
            }
            else
            {
                return listRole.FirstOrDefault();
            }
        }
    }
}