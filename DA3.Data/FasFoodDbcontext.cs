using DA3.Model.Models;
using DA3.Models.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA3.Data
{
    public class FasFoodDbcontext : IdentityDbContext<ApplicationUser>
    {
        public FasFoodDbcontext() : base("FasFoodConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<NewCategory> NewCategories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SlideGroup> SlideGroups { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Error>Errors { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<VisitorStatic> VisitorStatics { get; set; }
        public static FasFoodDbcontext Create()
        {
            return new FasFoodDbcontext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            modelBuilder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            modelBuilder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");

        }
    }
}
