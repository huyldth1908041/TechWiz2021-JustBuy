using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JustBuy.Models
{
    public class AppUser: IdentityUser
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
    }
}