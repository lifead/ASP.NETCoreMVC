using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStore.Domain;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities.Products;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    //[Route("api/[controller]")]
    [Route(WebAPI.Products)]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductData
    {
        private readonly IProductData _ProductData;

        public ProductsApiController(IProductData ProductData)
        {
            _ProductData = ProductData;
        }

        [HttpGet("sections")]
        public IEnumerable<Section> GetSections()
        {
            return _ProductData.GetSections();
        }

        [HttpGet("brands")]
        public IEnumerable<Brand> GetBrands()
        {
            return _ProductData.GetBrands();
        }

        [HttpPost]
        public IEnumerable<ProductDTO> GetProducts([FromBody] ProductFilter Filter = null)
        {
            return _ProductData.GetProducts(Filter);
        }

        [HttpGet("{id}")]
        public ProductDTO GetProductById(int id)
        {
            return _ProductData.GetProductById(id);
        }
    }
}