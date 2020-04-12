using System;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Domain.DTO.Blogs
{
    public class BlogResponseDTO : BaseEntity
    {
        /// <summary>
        /// Id Блога
        /// </summary>
        public int? BlogId { get; set; }

        /// <summary>
        /// Id Блога
        /// </summary>
        public int? BlogResponseId { get; set; }

        /// <summary>
        /// Родительская запись в блоге
        /// </summary>
        public virtual BlogResponseDTO ParentBlogResponse { get; set; }


        /// <summary>
        /// Id пользователя (автора)
        /// </summary>
        public string UserId { get; set; }

        public virtual User User { get; set; }


        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Рейтинг
        /// </summary>
        public string ResponseText { get; set; }

        /// <summary>
        /// Дата добавления ответа оценки 
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
