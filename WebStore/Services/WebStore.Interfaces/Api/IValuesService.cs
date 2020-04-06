using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Interfaces.Api
{
    public interface IValuesService
    {
        /// <summary>
        /// Получение всех строк
        /// </summary>
        /// <returns>все строки</returns>
        IEnumerable<string> Get();

        /// <summary>
        /// Асинхронный метод получения всех строк
        /// </summary>
        /// <returns>все строки</returns>
        Task<IEnumerable<string>> GetAsync();


        /// <summary>
        /// Получение строки по идентификатору
        /// </summary>
        /// <param name="id">идентификатор строки</param>
        /// <returns>Искомая строка</returns>
        string Get(int id);

        /// <summary>
        /// Асинхронный метод получение строки по идентификатору
        /// </summary>
        /// <param name="id">идентификатор строки</param>
        /// <returns>Искомая строка</returns>
        Task<string> GetAsync(int id);

        /// <summary>
        /// Создание новой строки
        /// </summary>
        /// <param name="value">новая строка</param>
        /// <returns>адрес доступа к новой строке</returns>
        Uri Post(string value);


        /// <summary>
        /// Асинхронный метод создание новой строки
        /// </summary>
        /// <param name="value">новая строка</param>
        /// <returns>адрес доступа к новой строке</returns>
        Task<Uri> PostAsync(string value);

        /// <summary>
        /// Редактирование строки
        /// </summary>
        /// <param name="id">идентификатор строки</param>
        /// <param name="value">новое значение строки</param>
        /// <returns>Код резальтата операции</returns>
        HttpStatusCode Put(int id, string value);

        /// <summary>
        ///  Асинхронный метод редактирование строки
        /// </summary>
        /// <param name="id">идентификатор строки</param>
        /// <param name="value">новое значение строки</param>
        /// <returns>Код резальтата операции</returns>
        Task<HttpStatusCode> PutAsync(int id, string value);

        /// <summary>
        /// Удаление строки по идентификатору
        /// </summary>
        /// <param name="id">идентификатор строки</param>
        /// <returns>Код резальтата операции</returns>
        HttpStatusCode Delete(int id);


        /// <summary>
        /// Асинхронный метод удаление строки по идентификатору
        /// </summary>
        /// <param name="id">идентификатор строки</param>
        /// <returns>Код резальтата операции</returns>
        Task<HttpStatusCode> DeleteAsync(int id);
    }
}
