using System.Collections.Generic;
using WebStore.Domain.Entities.Blog;

namespace WebStore.Interfaces.Services
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
        Blog GetById(int? id);
    }
}
