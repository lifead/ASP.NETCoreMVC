using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Domain.Entities.Blogs
{
    /// <summary>
    /// Блог
    /// </summary>
    public class Blog : BaseEntity, IOrderedEntity
    {
        /// <summary>
        /// Идентификатор пользователя (автора)
        /// </summary>
        public string UserId { get; set; }
        
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }


        public int Order { get; set; }

        /// <summary>
        /// Заголовок блога
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// Дата добавления блога
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Содержание блока
        /// </summary>
        [Column(TypeName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Список указанных оценок рейтинга
        /// </summary>
        public virtual ICollection<BlogRating> BlogRatings { get; set; }

        /// <summary>
        /// Список комментариев к блогу
        /// </summary>
        public virtual ICollection<BlogComment> BlogComments { get; set; }

        /// <summary>
        /// Список отзывов на блог
        /// </summary>
        public virtual ICollection<BlogResponse> BlogResponses { get; set; }
    }
}
