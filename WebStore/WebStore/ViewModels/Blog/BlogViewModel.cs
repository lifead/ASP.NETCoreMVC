using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.ViewModels.Blog
{
    /// <summary>
    /// Блог
    /// </summary>
    public class BlogViewModel : BaseEntity, IOrderedEntity
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
        public string Text { get; set; }

        /// <summary>
        /// Адрес изображения блога
        /// </summary>
        public string ImageUrl { get; set; }


        /// <summary>
        /// Список указанных оценок рейтинга
        /// </summary>
        public virtual IEnumerable<BlogRatingViewModel> BlogRatings { get; set; }

        /// <summary>
        /// Список комментариев к блогу
        /// </summary>
        public virtual IEnumerable<BlogCommentViewModel> BlogComments { get; set; }

        /// <summary>
        /// Список отзывов на блог
        /// </summary>
        public virtual IEnumerable<BlogResponseViewModel> BlogResponses { get; set; }
    }
}
