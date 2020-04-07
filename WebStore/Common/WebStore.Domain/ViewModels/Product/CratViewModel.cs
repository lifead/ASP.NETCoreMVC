using System.Collections.Generic;
using System.Linq;

namespace WebStore.Domain.ViewModels.Product
{
    /// <summary>
    /// Модель представления корзины
    /// </summary>
    public class CartViewModel
    {
        public Dictionary<ProductViewModel, int> Items { get; set; } = new Dictionary<ProductViewModel, int>();

        public int ItemsCount => Items?.Sum(item => item.Value) ?? 0;
    }
}