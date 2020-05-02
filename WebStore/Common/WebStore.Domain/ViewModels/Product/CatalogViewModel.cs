using System.Collections.Generic;

namespace WebStore.Domain.ViewModels.Product
{
    /// <summary>
    /// ViewModel для вывода перечня товаров
    /// </summary>
    public class CatalogViewModel
    {
        public int? BrandId { get; set; }

        public int? SectionId { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
