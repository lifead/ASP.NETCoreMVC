﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Entities.Orders;
using WebStore.Domain.ViewModels.Orders;
using WebStore.Domain.ViewModels.Product;
using WebStore.Infrastructure.Interfaces;


namespace WebStore.Infrastructure.Services.InSQL
{
    public class SqlOrderService : IOrderService
    {
        private readonly WebStoreDB _db;
        private readonly UserManager<User> _UserManager;

        public SqlOrderService(WebStoreDB db, UserManager<User> UserManager)
        {
            _db = db;
            _UserManager = UserManager;
        }

        public IEnumerable<Order> GetUserOrders(string UserName) => _db.Orders
           .Include(order => order.User)
           .Include(order => order.OrderItems)
           .Where(order => order.User.UserName == UserName)
           .AsEnumerable();

        public Order GetOrderById(int id) => _db.Orders
           .Include(order => order.OrderItems)
           .FirstOrDefault(order => order.Id == id);

        public async Task<Order> CreateOrderAsync(string UserName, CartViewModel Cart, OrderViewModel OrderModel)
        {
            var user = await _UserManager.FindByNameAsync(UserName);

            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                var order = new Order
                {
                    Name = OrderModel.Name,
                    Address = OrderModel.Address,
                    Phone = OrderModel.Phone,
                    User = user,
                    Date = DateTime.Now
                };

                await _db.Orders.AddAsync(order);

var _ids = Cart.Items.Select(x => x.Key.Id).AsEnumerable();
var _products = _db.Products.Where(x => _ids.Contains(x.Id)).AsEnumerable();
var _notFound = _products.Select(x => x.Id).Where(x => !_ids.Contains(x)).AsEnumerable();

if (_notFound.Count() > 0)
    throw new InvalidOperationException($"Товары с id:{string.Join(" ," , _notFound)} в базе данных отсутствуют!");



foreach (var (product_model, quantity) in Cart.Items)
{
    var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == product_model.Id);
    if (product is null)
        throw new InvalidOperationException($"Товар с id:{product_model.Id} в базе данных на найден!");

                    var order_item = new OrderItem
                    {
                        Order = order,
                        Price = product.Price,
                        Quantity = quantity,
                        Product = product
                    };

                    await _db.OrderItems.AddAsync(order_item);
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                return order;
            }
        }
    }
}