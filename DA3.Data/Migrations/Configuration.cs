namespace DA3.Data.Migrations
{
    using DA3.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DA3.Data.FasFoodDbcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DA3.Data.FasFoodDbcontext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new FasFoodDbcontext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new FasFoodDbcontext()));
            //var user = new ApplicationUser()
            //{
            //    UserName = "mighty",
            //    Email = "chien1642000@gmail.com",
            //    Birthday = DateTime.Now,
            //    FullName="Nguyễn văn chiến"
            //};

            //manager.Create(user, "123456");
            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}
            //var adminUser = manager.FindByEmail("chien1642000@gmail.com");
            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}
