using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Domain.Entities.Blogs
{
    /// <summary>
    /// Комментарий к записи блога
    /// </summary>
    public class BlogComment : BaseEntity, IOrderedEntity
    {
        public int Order { get; set; }

        /// <summary>
        /// Id Блога
        /// </summary>
        public int? BlogId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        /// <summary>
        /// Блог к которому относиться комментарий
        /// </summary>
        [ForeignKey(nameof(BlogId))]
        public virtual Blog Blog { get; set; }

        /// <summary>
        /// Id пользователя  (автора)
        /// </summary>
        public string UserId { get; set; }


        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Дата добавления комментария
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
