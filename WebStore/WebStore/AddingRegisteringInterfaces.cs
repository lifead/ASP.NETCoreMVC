using Microsoft.Extensions.DependencyInjection;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Services;

namespace WebStore
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
        public static IServiceCollection AddWebStoreInterfaces(this IServiceCollection services)
        {
            //AddTransient - каждый раз будет создавать экземпляр сервиса
            //AddScoped - один экземпляр сервиса на область вилимости
            //AddSingleton -   один экзеспляр на все время жизни приложения

            //Регистрация для работы со списком сотрудников
            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();

            //Регистрация для работы с перечнем секций, каталогов и фильтрами продуктов
            services.AddSingleton<IProductData, InMemoryProductData>();

            return services;
        }
    }
}
