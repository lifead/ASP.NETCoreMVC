using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services.InSQL
{
    public class SqlProductData : IProductData
    {
        public readonly WebStoreDB _db;

        public SqlProductData(WebStoreDB db) => _db = db;

        public IEnumerable<Brand> GetBrands() =>
            _db.Brands.Include(x => x.Products)
            .AsEnumerable();

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = _db.Products;
            if (Filter?.BrandId != null)
                query = query.Where(x => x.BrandId == Filter.BrandId);

            if (Filter?.SectionId != null)
                query = query.Where(x => x.SectionId == Filter.SectionId);

            return query.AsEnumerable();
        }

        public IEnumerable<Section> GetSections() =>
            _db.Sections.Include(x => x.Products)
            .AsEnumerable();
    }
}
