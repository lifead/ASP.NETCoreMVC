namespace WebStore.Domain.Models
{
    /// <summary>
    /// Элемент корзины
    /// </summary>
    public class CartItem
    {
        /// <summary>
        /// Идентификатор торовара
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Количество товара
        /// </summary>
        public int Quantity { get; set; }
    }
}

