using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Domain.DTO.Blogs
{
    public class BlogDTO : BaseEntity
    {
        /// <summary>
        /// Идентификатор пользователя (автора)
        /// </summary>
        public string UserId { get; set; }

        public virtual User User { get; set; }


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
        public string Text { get; set; }

        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Список указанных оценок рейтинга
        /// </summary>
        public virtual ICollection<BlogRatingDTO> BlogRatings { get; set; }

        /// <summary>
        /// Список комментариев к блогу
        /// </summary>
        public virtual ICollection<BlogCommentDTO> BlogComments { get; set; }

        /// <summary>
        /// Список отзывов на блог
        /// </summary>
        public virtual ICollection<BlogResponseDTO> BlogResponses { get; set; }
    }
}
