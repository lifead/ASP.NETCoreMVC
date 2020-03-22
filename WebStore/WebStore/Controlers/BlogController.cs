using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Controlers
{
    public class BlogController : Controller
    {
        private readonly IBlogData _BlogData;

        public BlogController(IBlogData BlogData) => _BlogData = BlogData;

        public IActionResult Index()
        {
            return View();
        }
    }
}