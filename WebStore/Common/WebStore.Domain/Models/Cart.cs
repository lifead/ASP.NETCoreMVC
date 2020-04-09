using System.Collections.Generic;
using System.Linq;

namespace WebStore.Domain.Models
{
    /// <summary>
    /// Корзина
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Товары в корзине
        /// </summary>
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        /// <summary>
        /// Количество товаров в корзине
        /// </summary>
        public int ItemsCount => Items?.Sum(item => item.Quantity) ?? 0;
    }
}