using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Entities.Products;
using System.Linq;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping.Products;
using AutoMapper;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class ProductsController : Controller
    {
        private readonly IProductData _ProductData;
        private readonly IMapper _Mapper;

        public ProductsController(IProductData ProductData, [FromServices] IMapper Mapper)
        {
            _ProductData = ProductData;
            _Mapper = Mapper;
        }

        public IActionResult Index([FromServices] IMapper Mapper) =>
           View(_ProductData.GetProducts().Products.Select(Mapper.Map<Product>));


        public IActionResult Edit(int? id)
        {
            var product = id is null ? 
                        new Product() :
                        _Mapper.Map<Product>(_ProductData.GetProductById((int)id));

            if (product is null)
                return NotFound();

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = _ProductData.GetProductById(id);

            if (product is null)
                return NotFound();

            return View(product.FromDTO());
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName(nameof(Delete))]
        public IActionResult DeleteConfirm(int id) => RedirectToAction(nameof(Index));
    }
}