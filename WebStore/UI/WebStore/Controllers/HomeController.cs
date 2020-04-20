using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using WebStore;
using WebStore.Controllers;
using WebStore.Services;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Throw(string id) => throw new ApplicationException(id);
        public IActionResult SomeAction() => View();
        public IActionResult Error404() => View();
        public IActionResult ContactUs() => View();
        public IActionResult ErrorStatus(string Code)
        {
            return View();
        }


    }
}