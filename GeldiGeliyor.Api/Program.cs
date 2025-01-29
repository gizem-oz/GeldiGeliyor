
using Autofac;
using Autofac.Extensions.DependencyInjection;
using GeldiGeliyor.Business.Concrete.Autofac;
using GeldiGeliyor.Business.Concrete.AutoMapper;
using GeldiGeliyor.DataAccess.Concrete.EFCore.Context;
using GeldiGeliyor.Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace GeldiGeliyor.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterModule<BusinessModule>();
            });
            builder.Services.AddAutoMapper(typeof(MapperProfile));

            builder.Services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.Password = new PasswordOptions()
                {
                    RequireLowercase = false,
                    RequireUppercase = false,
                    RequiredLength = 1,
                    RequireDigit = false,
                    RequiredUniqueChars = 0,
                    RequireNonAlphanumeric = false,
                };
            }).AddEntityFrameworkStores<GeldiGeliyorDbContext>()
    .AddDefaultTokenProviders();

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<GeldiGeliyorDbContext>(opt => opt.UseSqlServer(connectionString));

            //Genel manada kullanılan paketleri buraya dahil ederiz. Şu an burada olan şey, default kimlik doğrulamasını jwt ile değiştirmek

            // Guvenlik ile alakali policy durumlarini dahil ettik.
            builder.Services.AddCors(x => x.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "localhost",
                    ValidAudience = "localhost",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("benimadimnameamasadecebukadarladakalmazabdurrahmandaolabilirdi")),
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
