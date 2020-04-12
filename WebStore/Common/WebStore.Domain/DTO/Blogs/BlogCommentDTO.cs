using System;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Domain.DTO.Blogs
{
    public class BlogCommentDTO : BaseEntity
    {
        /// <summary>
        /// Id Блога
        /// </summary>
        public int? BlogId { get; set; }

        public virtual User User { get; set; }

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
