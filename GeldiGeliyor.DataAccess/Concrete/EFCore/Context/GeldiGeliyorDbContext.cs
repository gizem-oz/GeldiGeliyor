using GeldiGeliyor.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GeldiGeliyor.DataAccess.Concrete.EFCore.Context
{
    public class GeldiGeliyorDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public GeldiGeliyorDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category>Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Picture> Pictures{ get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Seller> Sellers{ get; set; }


    }
}
