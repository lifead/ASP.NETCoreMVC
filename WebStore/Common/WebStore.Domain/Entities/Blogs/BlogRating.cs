using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Domain.Entities.Blogs
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
        /// Id пользователя (автора)
        /// </summary>
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

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
