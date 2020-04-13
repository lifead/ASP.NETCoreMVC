using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebStore.DAL.Context;
using WebStore.Domain.Entities.Identity;
using WebStore.Interfaces.Services;
using WebStore.Services.Blogs.InSQL;
using WebStore.Services.Products.InCookies;
using WebStore.Services.Products.InMemory;
using WebStore.Services.Products.InSQL;

namespace WebStore.ServiceHosting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
            services.AddScoped<IProductData, SqlProductData>();
            services.AddScoped<IOrderService, SqlOrderService>();
            services.AddScoped<IBlogData, SqlBlogData>();
            //services.AddScoped<ICartService, CookiesCartService>();
            //services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<WebStoreDB>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>(x =>
            {
                x.Password.RequiredLength = 3;
                x.Password.RequireDigit = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireLowercase = true;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequiredUniqueChars = 3;

                x.User.RequireUniqueEmail = false;

                x.Lockout.AllowedForNewUsers = true;
                x.Lockout.MaxFailedAccessAttempts = 10;
                x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            })
               .AddEntityFrameworkStores<WebStoreDB>()
               .AddDefaultTokenProviders();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
