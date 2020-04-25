using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities.Products;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping;
using WebStore.Services.Mapping.Products;

namespace WebStore.Services.Products.InSQL
{
    public class SqlProductData : IProductData
    {
        public readonly WebStoreDB _db;

        public SqlProductData(WebStoreDB db) => _db = db;

        public IEnumerable<Brand> GetBrands() =>
            _db.Brands
            //.Include(x => x.Products)
            .AsEnumerable();

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = _db.Products.Include(x => x.Brand).Include(x => x.Section);

            if (Filter?.BrandId != null)
                query = query.Where(product => product.BrandId == Filter.BrandId);

            if (Filter?.SectionId != null)
                query = query.Where(product => product.SectionId == Filter.SectionId);

            if (Filter?.Ids?.Count > 0)
                query = query.Where(product => Filter.Ids.Contains(product.Id));

            return query.AsEnumerable().Select(ProductMapping.ToDTO);
        }

        public IEnumerable<Section> GetSections()
        {
            return _db.Sections
                 //.Include(x => x.Products)
                 .AsEnumerable();
        }

        public SectionDTO GetSectionById(int id) => _db.Sections.FirstOrDefault(s => s.Id == id).ToDTO();

        public BrandDTO GetBrandById(int id) => _db.Brands.Find(id).ToDTO();

        public ProductDTO GetProductById(int id)
        {
            return _db.Products
                .Include(p => p.Brand)
                .Include(p => p.Section)
                .FirstOrDefault(p => p.Id == id)
                .ToDTO();
        }
    }
}
