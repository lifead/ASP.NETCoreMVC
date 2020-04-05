using System;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.ViewModels.Blog
{
    /// <summary>
    /// Ответ на запись в блоге
    /// </summary>
    public class BlogResponseViewModel : BaseEntity, IOrderedEntity
    {
        public int Order { get; set; }

        /// <summary>
        /// Id Блога
        /// </summary>
        public int? BlogId { get; set; }

        /// <summary>
        /// Блог к которому относиться ответ на запись
        /// </summary>
        public virtual BlogViewModel Blog { get; set; }


        /// <summary>
        /// Id Блога
        /// </summary>
        public int? BlogResponseId { get; set; }


        /// <summary>
        /// Родительская запись в блоге
        /// </summary>
        public virtual BlogResponseViewModel ParentBlogResponse { get; set; }


        /// <summary>
        /// Id пользователя
        /// </summary>
        public int UserId { get; set; }


        /// <summary>
        /// Автор ответа на запись в блоге
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Адрес изображения отзыва
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
