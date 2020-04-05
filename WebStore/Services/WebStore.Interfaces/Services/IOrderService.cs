using System.Collections.Generic;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Orders;
using WebStore.Domain.ViewModels.Orders;
using WebStore.Domain.ViewModels.Product;


namespace WebStore.Interfaces.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetUserOrders(string UserName);

        Order GetOrderById(int id);

        Task<Order> CreateOrderAsync(string UserName, CartViewModel Cart, OrderViewModel OrderModel);
    }
}