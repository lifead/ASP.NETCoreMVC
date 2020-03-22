using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Ответ на запись в блоге
    /// </summary>
    public class BlogResponse : BaseEntity, IOrderedEntity
    {
        public int Order { get; set; }

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
        /// Id пользователя
        /// </summary>
        public int UserId { get; set; }


        /// <summary>
        /// Автор ответа на запись в блоге
        /// </summary>
        public string Author { get; set; }

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
