using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.ViewModels.Orders;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Orders([FromServices] IOrderService OrderService)
        {
            var userOrders = OrderService.GetUserOrders(User.Identity.Name);
            var userOrdersViewModel = userOrders.Select(order => new UserOrderViewModel
                                        {
                                            Id = order.Id,
                                            Name = order.Name,
                                            Address = order.Address,
                                            Phone = order.Phone,
                                            TotalSum = order.OrderItems.Sum(i => i.Price * i.Quantity)
                                        });

            return View(userOrdersViewModel);
        }
    }
}