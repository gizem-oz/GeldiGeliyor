using Autofac;
using Autofac.Extensions.DependencyInjection;
using GeldiGeliyor.Business.Concrete.Autofac;
using GeldiGeliyor.Business.Concrete.AutoMapper;
using GeldiGeliyor.DataAccess.Concrete.EFCore.Context;
using GeldiGeliyor.Entities.Concrete;
using GeldiGeliyor.WebUI.Models.BasketTransaction;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GeldiGeliyor.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

           
            builder.Services.AddHttpContextAccessor();

            // Autofac ServiceProviderFactory'yi ayarlıyoruz
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            // Autofac ile container'a modülü ekliyoruz
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterModule<BusinessModule>();
            });

            builder.Services.AddScoped<IBasketTransaction, BasketTransaction>();

            builder.Services.AddAutoMapper(typeof(MapperProfile));

            builder.Services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password = new PasswordOptions()
                {
                     RequireLowercase= false,
                      RequireUppercase= false, 
                       RequiredLength=1,
                        RequireDigit=false,
                         RequiredUniqueChars= 0,
                          RequireNonAlphanumeric= false,
                };
            }).AddEntityFrameworkStores<GeldiGeliyorDbContext>()
    .AddDefaultTokenProviders(); 

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<GeldiGeliyorDbContext>(opt => opt.UseSqlServer(connectionString));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
