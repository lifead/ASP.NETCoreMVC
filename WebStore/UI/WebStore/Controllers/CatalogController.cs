﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Products;
using WebStore.Domain.ViewModels;
using WebStore.Domain.ViewModels.Product;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping;
using WebStore.Services.Mapping.Products;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _ProductData;
        private readonly IConfiguration _Configuration;

        public CatalogController(IProductData ProductData, IConfiguration Configuration)
        {
            _ProductData = ProductData;
            _Configuration = Configuration;
        }

        public IActionResult Shop(int? SectionId, int? BrandId, int Page = 1)
        {
            var page_size = int.TryParse(_Configuration["PageSize"], out var size) ? size : (int?)null;

            var filter = new ProductFilter
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Page = Page,
                PageSize = page_size
            };
            var products = _ProductData.GetProducts(filter);

            return View(new CatalogViewModel
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Products = products.Products.Select(ProductMapping.FromDTO).Select(ProductMapping.ToView).OrderBy(p => p.Order),
                PageViewModel = new PageViewModel
                {
                    PageSize = page_size ?? 0,
                    PageNumber = Page,
                    TotalItems = products.TotalCount
                }
            });
        }

        public IActionResult Details(int id)
        {
            var product = _ProductData.GetProductById(id);

            if (product is null)
                return NotFound();

            return View(product.FromDTO().ToView());
        }
    }
}