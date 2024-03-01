using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UdemySignalRProject.EntityLayer.Entities;

namespace UdemySignalRProject.DAL.Concreate
{
    public class SignalRContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public SignalRContext(DbContextOptions<SignalRContext> options) : base(options)
        {



        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<MoneyCase> MoneyCases { get; set; }
        public DbSet<MenuTable> MenuTables { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(SignalRContext)));
            base.OnModelCreating(modelBuilder);
        }
    }


}
