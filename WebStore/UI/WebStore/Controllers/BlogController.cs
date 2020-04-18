using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore;
using WebStore.Controllers;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping.Blogs;

namespace WebStore.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogData _BlogData;

        public BlogController(IBlogData BlogData) => _BlogData = BlogData;

        public IActionResult Index()
        {
            var blogs = _BlogData.GetAll().Select(x => x.FromDTO().ToView()).ToList();
            return View(blogs);
        }

        public IActionResult BlogSingle(int? Id)
        {
            var singleBlog = _BlogData.GetById(Id).FromDTO().ToView();
            return View(singleBlog);
        }
    }
}