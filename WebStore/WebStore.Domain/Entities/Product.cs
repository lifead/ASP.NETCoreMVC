using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey(nameof(SectionId))]
        public virtual Section Section { get; set; }

        /// <summary>
        /// Идентификатор бренда
        /// </summary>
        public int? BrandId { get; set; }


        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }

        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
