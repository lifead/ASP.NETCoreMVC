using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Mapping.Blog;

namespace WebStore.Controlers
{
    public class BlogController : Controller
    {
        private readonly IBlogData _BlogData;

        public BlogController(IBlogData BlogData) => _BlogData = BlogData;

        public IActionResult Index()
        {
            var blogs = _BlogData.GetAll().Select(x => x.ToView()).ToList();
            return View(blogs);
        }

        public IActionResult BlogSingle(int Id)
        {
            var singleBlog = _BlogData.GetById(Id).ToView();
            return View(singleBlog);
        }
    }
}