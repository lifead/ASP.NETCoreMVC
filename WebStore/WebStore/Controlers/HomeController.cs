using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStore.Models;
using WebStore.Services;

namespace WebStore.Controlers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult SomeAction() => View();

        public IActionResult Error404() => View();
        public IActionResult Cart() => View();
        public IActionResult CheckOut() => View();
        public IActionResult ContactUs() => View();


    }
}