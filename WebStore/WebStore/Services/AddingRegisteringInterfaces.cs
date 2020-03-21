using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Services.InMemory;
using WebStore.Infrastructure.Services.InSQL;

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

            //AddTransient - каждый раз будет создавать экземпляр сервиса
            //AddScoped - один экземпляр сервиса на область вилимости
            //AddSingleton -   один экзеспляр на все время жизни приложения

            //Регистрация для работы со списком сотрудников
            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();

            //Регистрация для работы с перечнем секций, каталогов и фильтрами продуктов
            //services.AddSingleton<IProductData, InMemoryProductData>();
            services.AddScoped<IProductData, SqlProductData>();

            services.AddTransient<WebStoreDBInitializer>();

            return services;
        }
    }
}
