using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using WebStore.DAL.Context;
using WebStore.Domain.Entities.Identity;
using WebStore.Interfaces.Services;
using WebStore.Logger.Log4Net;
using WebStore.Services.Blogs.InSQL;
using WebStore.Services.Data;
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

            #region Сервисы Бизнес-логики
            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
            services.AddScoped<IProductData, SqlProductData>();
            services.AddScoped<IOrderService, SqlOrderService>();
            services.AddScoped<IBlogData, SqlBlogData>();
            services.AddScoped<ICartService, CookiesCartService>(); 
            #endregion

            #region База данных
            services.AddDbContext<WebStoreDB>(opt =>
                    opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<WebStoreDBInitializer>();
            #endregion

            #region Identity
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
            #endregion

            #region Swagger
            //services.AddSwaggerGen(opt =>
            //{
            //    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "WebStore.API", Version = "v1" });

            //    //opt.IncludeXmlComments("WebStore.ServiceHosting.xml");

            //    const string domain_doc_xml = "WebStore.Domain.xml";
            //    const string debug_path = @"bin\Debug\netcoreapp3.1";
            //    if (File.Exists(domain_doc_xml))
            //        opt.IncludeXmlComments(domain_doc_xml);
            //    else if (File.Exists(Path.Combine(debug_path, domain_doc_xml)))
            //        opt.IncludeXmlComments(Path.Combine(debug_path, domain_doc_xml));
            //}); 
            #endregion
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebStoreDBInitializer db, ILoggerFactory log)
        {
            log.AddLog4Net();

            db.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            #region UseSwagger
            //app.UseSwagger();
            //app.UseSwaggerUI(opt =>
            //{
            //    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "WebStore.API");
            //    opt.RoutePrefix = string.Empty;
            //}); 
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
