using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.ViewModels.Product;
using WebStore.Interfaces.Services;
using WebStore.Services;


namespace WebStore.Components
{
    /// <summary>
    /// Визуальный компонент для отображения перечня брэндов
    /// </summary>
    public class BrandsViewComponent : ViewComponent
    {

        private readonly IProductData _ProductData;
        private readonly IMapper _Mapper;

        public BrandsViewComponent(IProductData ProductData, [FromServices] IMapper Mapper)
        {
            _ProductData = ProductData;
            _Mapper = Mapper;
        }

        public IViewComponentResult Invoke() => View(GetBrands());

        /// <summary>
        /// Получить все бренды
        /// </summary>
        /// <returns>Перечень </returns>
        public IEnumerable<BrandViewModel> GetBrands() => _ProductData
           .GetBrands()
           .Select(brand => _Mapper.Map<BrandViewModel>(brand))
           .OrderBy(brand => brand.Order);
    }
}
