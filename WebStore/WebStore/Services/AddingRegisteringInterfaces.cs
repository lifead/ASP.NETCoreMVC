using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Services.InMemory;
using WebStore.Infrastructure.Services.InSQL;
using WebStore.Infrastructure.Services.InCookies;

namespace WebStore.Services
{
    /// <summary>
    /// Класс расширения для регистрации интерфейсов данного приложения
    /// </summary>
    public static class AddingRegisteringInterfaces
    {
        /// <summary>
        /// Метод расширения для регистрации интерфейсов данного приложения
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebStoreInterfaces(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<WebStoreDB>(opt =>
                   opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Role>()
               .AddEntityFrameworkStores<WebStoreDB>()
               .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(x =>
            {
                x.Password.RequiredLength = 3;
                x.Password.RequireDigit = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireLowercase = true;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequiredUniqueChars = 3;

                //opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCD...123457890";
                x.User.RequireUniqueEmail = false;

                x.Lockout.AllowedForNewUsers = true;
                x.Lockout.MaxFailedAccessAttempts = 10;
                x.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            });

            services.ConfigureApplicationCookie(x =>
            {
                x.Cookie.Name = "WebStore";
                x.Cookie.HttpOnly = true;
                x.ExpireTimeSpan = TimeSpan.FromDays(10);

                x.LoginPath = "/Account/Login";
                x.LogoutPath = "/Account/Logout";
                x.AccessDeniedPath = "/Account/AccessDenied";

                x.SlidingExpiration = true;
            });



            //AddTransient - каждый раз будет создавать экземпляр сервиса
            //AddScoped - один экземпляр сервиса на область вилимости
            //AddSingleton -   один экзеспляр на все время жизни приложения

            //Регистрация для работы со списком сотрудников
            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();

            //Регистрация для работы с перечнем секций, каталогов и фильтрами продуктов
            //services.AddSingleton<IProductData, InMemoryProductData>();
            services.AddScoped<IProductData, SqlProductData>();
            services.AddScoped<IBlogData, SqlBlogData>();
            services.AddScoped<ICartService, CookiesCartService>();

            services.AddTransient<WebStoreDBInitializer>();

            return services;
        }
    }
}
