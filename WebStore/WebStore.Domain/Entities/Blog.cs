using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Блог
    /// </summary>
    public class Blog : BaseEntity, IOrderedEntity
    {

        public int Order { get; set; }

        /// <summary>
        /// Заголовок блога
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Автор блога
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Дата добавления блога
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Содержание блока
        /// </summary>
        [Column(TypeName ="text")]
        public string Text { get; set; }

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
