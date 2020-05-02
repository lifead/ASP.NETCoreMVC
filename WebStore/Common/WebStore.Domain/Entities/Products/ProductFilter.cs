using System.Collections.Generic;

namespace WebStore.Domain.Entities.Products
{
    /// <summary>
    /// Фильтр товаров (продуктов)
    /// </summary>
    public class ProductFilter
    {
        /// <summary>
        /// Номер (идентификатор) искомого секции
        /// </summary>
        public int? SectionId { get; set; }

        /// <summary>
        /// Номер (идентификатор) искомого бренда
        /// </summary>
        public int? BrandId { get; set; }


        /// <summary>
        /// Список идентификаторов продуктов
        /// </summary>
        public List<int> Ids { get; set; }

        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Общее количество страниц
        /// </summary>
        public int? PageSize { get; set; }
    }
}
