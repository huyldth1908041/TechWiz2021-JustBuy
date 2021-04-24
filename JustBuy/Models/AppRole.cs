using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustBuy.Models
{
    public class AppRole: IdentityRole
    {
        public string Description { get; set; }
        public RoleStatus Status { get; set; }

        public enum RoleStatus
        {
            Active,
            DeActive
        }
    }
}