using JustBuy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustBuy.IdentityConfig
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {
        }

        // this method is called by Owin therefore this is the best place to configure your User Manager
        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            AppDataContext dbContext = context.Get<AppDataContext>();
            UserStore<AppUser> userStore = new UserStore<AppUser>(dbContext);
            var manager = new AppUserManager(userStore);

            return manager;


        }
    }
    public class AppRoleManager : RoleManager<AppRole>
    {
        public AppRoleManager(RoleStore<AppRole> store) : base(store)
        {
        }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            AppDataContext dbContext = context.Get<AppDataContext>();
            RoleStore<AppRole> roleStore = new RoleStore<AppRole>(dbContext);
            var manager = new AppRoleManager(roleStore);
            return manager;
        }


    }
}