using System;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.ViewModels.Blog
{
    /// <summary>
    /// Комментарий к записи блога
    /// </summary>
    public class BlogCommentViewModel : BaseEntity, IOrderedEntity
    {
        public int Order { get; set; }

        /// <summary>
        /// Id Блога
        /// </summary>
        public int? BlogId { get; set; }

        /// <summary>
        /// Блог к которому относиться комментарий
        /// </summary>
        public virtual BlogViewModel Blog { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public int UserId { get; set; }


        /// <summary>
        /// Автор комментария
        /// </summary>
        public string Author { get; set; }

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
