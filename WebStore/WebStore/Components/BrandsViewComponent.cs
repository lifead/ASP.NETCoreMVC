using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Services;
using WebStore.ViewModels;

namespace WebStore.Components
{
    /// <summary>
    /// Визуальный компонент для отображения перечня брэндов
    /// </summary>
    public class BrandsViewComponent : ViewComponent
    {

        private readonly IProductData _ProductData;

        public BrandsViewComponent(IProductData ProductData) => _ProductData = ProductData;

        public IViewComponentResult Invoke() => View(GetBrands());

        /// <summary>
        /// Получить все бренды
        /// </summary>
        /// <returns>Перечень </returns>
        public IEnumerable<BrandViewModel> GetBrands() => _ProductData
           .GetBrands()

           .Select(brand=>  ExampleMapping.Mapp<BrandViewModel>(brand))
           .OrderBy(brand => brand.Order);
    }
}
