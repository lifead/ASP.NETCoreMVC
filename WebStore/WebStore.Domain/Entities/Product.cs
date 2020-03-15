using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.Entities
{
    /// <summary>
    /// Продукт
    /// </summary>
    public class Product : NamedEntity, IOrderedEntity
    {

        public int Order { get; set; }

        /// <summary>
        /// Идентификатор секции
        /// </summary>
        public int SectionId { get; set; }

        /// <summary>
        /// Идентификатор бренда
        /// </summary>
        public int? BrandId { get; set; }

        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }
    }
}
