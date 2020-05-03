using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebStore;
using WebStore.Clients.Blogs;
using WebStore.Clients.Employees;
using WebStore.Clients.Identity;
using WebStore.Clients.Orders;
using WebStore.Clients.Products;
using WebStore.Clients.Values;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure;
using WebStore.Infrastructure.AutoMapper;
using WebStore.Interfaces.Api;
using WebStore.Interfaces.Services;
using WebStore.Services;
using WebStore.Services.Blogs.InSQL;
using WebStore.Services.Data;
using WebStore.Services.Products;
using WebStore.Services.Products.InCookies;
using WebStore.Services.Products.InMemory;
using WebStore.Services.Products.InSQL;

namespace WebStore.Infrastructure
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
            services.AddSignalR();

            services.AddAutoMapper(x => 
            {
                x.AddProfile<DTOMapping>();
                x.AddProfile<ViewModelMapping>();
            }, typeof(Startup));

            services.AddIdentity<User, Role>()
               .AddDefaultTokenProviders();

            #region WebAPI Identity clients stores

            services
               .AddTransient<IUserStore<User>, UsersClient>()
               .AddTransient<IUserPasswordStore<User>, UsersClient>()
               .AddTransient<IUserEmailStore<User>, UsersClient>()
               .AddTransient<IUserPhoneNumberStore<User>, UsersClient>()
               .AddTransient<IUserTwoFactorStore<User>, UsersClient>()
               .AddTransient<IUserLockoutStore<User>, UsersClient>()
               .AddTransient<IUserClaimStore<User>, UsersClient>()
               .AddTransient<IUserLoginStore<User>, UsersClient>();
            services
               .AddTransient<IRoleStore<Role>, RolesClient>();

            #endregion


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
            services.AddSingleton<IEmployeesData, EmployeesClient>();
            services.AddScoped<IProductData, ProductsClient>();
            services.AddScoped<IOrderService, OrdersClient>();
            services.AddScoped<IBlogData, BlogsClient>();
            services.AddScoped<IValuesService, ValuesClient>();

            services.AddScoped<ICartStore, CookiesCartStore>();
            services.AddScoped<ICartService, CartService>();

            return services;
        }
    }
}
