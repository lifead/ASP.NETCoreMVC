﻿using System.Collections.Generic;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities.Products;

namespace WebStore.Interfaces.Services
{
    /// <summary>
    /// Каталог товаров
    /// </summary>
    public interface IProductData
    {
        /// <summary>
        /// Получить все секции
        /// </summary>
        /// <returns>Перечисление секций каталога</returns>
        IEnumerable<Section> GetSections();

        SectionDTO GetSectionById(int id);

        /// <summary>
        /// Получить все бренды
        /// </summary>
        /// <returns>Перечисление брендов каталога</returns>
        IEnumerable<Brand> GetBrands();

        BrandDTO GetBrandById(int id);

        /// <summary>
        /// Товары из каталога
        /// </summary>
        /// <param name="Filter">Критерий поиска/фильтрации</param>
        /// <returns>Искомые товары из каталога товаров</returns>
        PagedProductsDTO GetProducts(ProductFilter Filter = null);

        /// <summary>Получить товар по идентификатору</summary>
        /// <param name="id">Идентификатор требуемого товара</param>
        /// <returns>Товар</returns>
        ProductDTO GetProductById(int id);
    }
}
