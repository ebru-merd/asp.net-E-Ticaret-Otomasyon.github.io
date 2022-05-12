using Kouzon_E_Ticaret.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kouzon_E_Ticaret.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "admin", Description = "Admin Rolü"};

                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "user", Description = "user Rolü" };

                manager.Create(role);
            }
            if (!context.Users.Any(i => i.Name == "ebrumerd"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "Ebru", Surname = "Merd", UserName = "ebrumerd", Email = "ebrumerd@gmail.com"};


                manager.Create(user, "ebrumerd");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
            if (!context.Users.Any(i => i.Name == "yigittaskin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "Yiğit", Surname = "Taşkın", UserName = "yigittaskin", Email = "taskinyigit84@gmail.com" };


                manager.Create(user, "yigittaskin");
                //manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }


            base.Seed(context);
        }
    }
}