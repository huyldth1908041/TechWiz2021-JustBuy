using JustBuy.IdentityConfig;
using JustBuy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace JustBuy.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            AppUser user = userManager.Find(login.UserName, login.Password);
            if (user != null)
            {
                var ident = userManager.CreateIdentity(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                //use the instance that has been created. 
                authManager.SignIn(
                    new AuthenticationProperties { IsPersistent = login.RememberMe }, ident);
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View(login);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Register(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();

            }
            //to do Avartar
            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Phone = model.Phone,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = AppUser.UserStatus.Active,
                FullName = model.FullName

            };


            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var createUserResult = await userManager.CreateAsync(user, model.Password);
            var authManager = HttpContext.GetOwinContext().Authentication;
            if (!createUserResult.Succeeded)
            {
                var errorMsg = new StringBuilder();
                foreach (var err in createUserResult.Errors)
                {
                    errorMsg.Append(err);
                    errorMsg.Append(", ");
                }

                ModelState.AddModelError("", errorMsg.ToString());

                return View();
            }
            //login user
            var ident = userManager.CreateIdentity(user,
                      DefaultAuthenticationTypes.ApplicationCookie);
            //use the instance that has been created. 
            authManager.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
            return Redirect(Url.Action("Index", "Home"));

        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
        [Authorize]
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> MyAccount()
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;
            var user = await userManager.FindByIdAsync(User.Identity.GetUserId());
            if(user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            var viewModel = new UpdateProfileViewModel
            {
                Address = user.Address,
                Email = user.Email,
                FullName = user.FullName,
                Phone = user.Phone,
                Orders = user.Orders.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        [Authorize]
        public async System.Threading.Tasks.Task<ActionResult> UpdateProfile(UpdateProfileViewModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;
            var currentUser = await userManager.FindByIdAsync(User.Identity.GetUserId());
            if (currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            //update
            currentUser.Address = model.Address;
            currentUser.FullName = model.FullName;
            currentUser.Phone = model.Phone;
            currentUser.Email = model.Email;
            userManager.Update(currentUser);
            return RedirectToAction("MyAccount", "Account");
        }
    }
}