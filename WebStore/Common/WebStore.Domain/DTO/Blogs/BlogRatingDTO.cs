using System;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Domain.DTO.Blogs
{
    public class BlogRatingDTO : BaseEntity
    {
        /// <summary>
        /// Id Блога
        /// </summary>
        public int? BlogId { get; set; }

        /// <summary>
        /// Id пользователя (автора)
        /// </summary>
        public string UserId { get; set; }

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
