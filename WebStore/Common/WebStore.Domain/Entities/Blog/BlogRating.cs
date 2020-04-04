using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.Entities.Blog
{
    /// <summary>
    /// Рейтинг блога
    /// </summary>
    public class BlogRating : BaseEntity
    {
        /// <summary>
        /// Id Блога
        /// </summary>
        public int? BlogId { get; set; }


        [ForeignKey(nameof(BlogId))]
        public virtual Blog Blog { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Рейтинг
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Дата указания оценки
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
