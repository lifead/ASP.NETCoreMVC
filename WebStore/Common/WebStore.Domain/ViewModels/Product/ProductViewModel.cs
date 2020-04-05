using WebStore.Domain.Entities.Base.Interfaces;

namespace WebStore.Domain.ViewModels.Product
{
    /// <summary>
    /// ViewModel для вывода товара
    /// </summary>
    public class ProductViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        /// <summary>
        /// Адрес изображения товара
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Цена товара
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Брэнд товара
        /// </summary>
        public string Brand { get; set; }
    }
}
