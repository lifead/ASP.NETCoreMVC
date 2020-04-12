using System.Collections.Generic;
using WebStore.Domain.DTO.Blogs;
using WebStore.Domain.Entities.Blogs;

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
        IEnumerable<BlogDTO> GetAll();

        /// <summary>
        /// Блог
        /// </summary>
        /// <param name="id">Идентификатор блога</param>
        /// <returns>Экземпляр блога</returns>
        BlogDTO GetById(int? id);
    }
}
