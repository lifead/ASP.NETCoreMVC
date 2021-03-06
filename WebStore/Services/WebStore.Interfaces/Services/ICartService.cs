﻿using WebStore.Domain.ViewModels.Product;


namespace WebStore.Interfaces.Services
{
    /// <summary>
    /// Описание интерфейса корзины
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// Добавить в корзину по идентификатору
        /// </summary>
        /// <param name="id"></param>
        void AddToCart(int id);

        /// <summary>
        /// Уменьшить количество товара на 1 единицу по идентификатору
        /// </summary>
        /// <param name="id"></param>
        void DecrementFromCart(int id);

        /// <summary>
        /// Удалить товар из корзины
        /// </summary>
        /// <param name="id"></param>
        void RemoveFromCart(int id);


        /// <summary>
        /// Удалить все из корзины
        /// </summary>
        void RemoveAll();

        /// <summary>
        /// Сформировать модель представления корзины
        /// </summary>
        /// <returns></returns>
        CartViewModel TransformFromCart();
    }
}