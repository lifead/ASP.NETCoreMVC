using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    public class CartAPIController : Controller
    {
        private readonly ICartService _CartService;

        public CartAPIController(ICartService CartService)
        {
            _CartService = CartService;
        }

        public IActionResult GetCartView() => ViewComponent("Cart");


        public IActionResult AddToCartAPI(int id)
        {
            _CartService.AddToCart(id);
            return Json(new { id, message = $"Товар id {id} был добавлен в корзину"});
        }

        public IActionResult DecrementFromCartAPI(int id)
        {
            _CartService.DecrementFromCart(id);
            return Json(new { id, message = $"Количество товара с id {id} было уменьшено на 1" });
        }

        public IActionResult RemoveFromCartAPI(int id)
        {
            _CartService.RemoveFromCart(id);
            return Json(new { id, message = $"Товар с id {id} был удален из корзины" });

        }

        public IActionResult RemoveAllAPI()
        {
            _CartService.RemoveAll();
            return Json(new { message = $"Корзина успешно очищена" });

        }


    }
}