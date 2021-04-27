using JustBuy.IdentityConfig;
using JustBuy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JustBuy.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        [HttpPost]
        public ActionResult MakeUser(string userId)
        {
            if(userId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var roleManager = HttpContext.GetOwinContext().Get<AppRoleManager>();
            //get current user
            var user = userManager.FindByIdAsync(userId).Result;
            var existedRole = roleManager.FindByNameAsync("User").Result;
            if (existedRole == null)
            {
                var createRoleResult =  roleManager.CreateAsync(new AppRole { Name = "User" }).Result;
                if (!createRoleResult.Succeeded)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
                }
            }
            //add to role user
            var addToRoleResutlt = userManager.AddToRole(user.Id, "User");
            if (!addToRoleResutlt.Succeeded)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);

            
            }

            return RedirectToAction("ListAccounts", "Admin");
        }

        [HttpPost]
        public ActionResult MakeAdmin(string userId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var roleManager = HttpContext.GetOwinContext().Get<AppRoleManager>();
            //get current user
            var user = userManager.FindByIdAsync(userId).Result;
            var existedRole = roleManager.FindByNameAsync("Admin").Result;
            if (existedRole == null)
            {
                var createRoleResult = roleManager.CreateAsync(new AppRole { Name = "Admin" }).Result;
                if (!createRoleResult.Succeeded)
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
                }
            }
            //add to role user
            var addToRoleResutlt = userManager.AddToRole(user.Id, "Admin");
            if (!addToRoleResutlt.Succeeded)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);


            }

            return RedirectToAction("ListAccounts", "Admin");
        }
    }
}