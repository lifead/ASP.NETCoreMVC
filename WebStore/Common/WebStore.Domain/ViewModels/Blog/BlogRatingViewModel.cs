﻿using System;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.ViewModels.Blog
{
    /// <summary>
    /// Рейтинг блога
    /// </summary>
    public class BlogRatingViewModel : BaseEntity
    {
        /// <summary>
        /// Id Блога
        /// </summary>
        public int? BlogId { get; set; }

        public virtual BlogViewModel Blog { get; set; }

        /// <summary>
        /// Id пользователя
        /// </summary>
        public string UserId { get; set; }

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
