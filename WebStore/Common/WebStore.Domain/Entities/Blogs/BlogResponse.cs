using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Domain.Entities.Blogs
{
    /// <summary>
    /// Ответ на запись в блоге
    /// </summary>
    public class BlogResponse : BaseEntity
    {
        /// <summary>
        /// Id Блога
        /// </summary>
        public int? BlogId { get; set; }

        /// <summary>
        /// Блог к которому относиться ответ на запись
        /// </summary>
        [ForeignKey(nameof(BlogId))]
        public virtual Blog Blog { get; set; }


        /// <summary>
        /// Id Блога
        /// </summary>
        public int? BlogResponseId { get; set; }


        /// <summary>
        /// Родительская запись в блоге
        /// </summary>
        [ForeignKey(nameof(BlogResponseId))]
        public virtual BlogResponse ParentBlogResponse { get; set; }


        /// <summary>
        /// Id пользователя (автора)
        /// </summary>
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
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
