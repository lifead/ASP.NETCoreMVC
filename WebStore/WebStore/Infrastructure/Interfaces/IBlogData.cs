using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;

namespace WebStore.Infrastructure.Interfaces
{
    /// <summary>
    /// Список блогов
    /// </summary>
    public interface IBlogData
    {
        /// <summary>
        /// Получить все блоги
        /// </summary>
        /// <returns>Перечень блогов сайта</returns>
        IEnumerable<Blog> GetAll();

        /// <summary>
        /// Блог
        /// </summary>
        /// <param name="id">Идентификатор блога</param>
        /// <returns>Экземпляр блога</returns>
        Blog GetById(int id);
    }
}
