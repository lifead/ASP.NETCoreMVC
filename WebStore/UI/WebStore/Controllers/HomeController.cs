using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStore;
using WebStore.Controllers;
using WebStore.Services;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult SomeAction() => View();
        public IActionResult Error404() => View();
        public IActionResult ContactUs() => View();


    }
}