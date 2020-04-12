using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Domain.Entities.Blogs;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebAPI.Blogs)]
    [ApiController]
    public class BlogsApiController : ControllerBase, IBlogData
    {
        private readonly IBlogData _IBlogData;

        public BlogsApiController(IBlogData BlogData) => _IBlogData = BlogData;

        [HttpGet]
        public IEnumerable<Blog> GetAll()
        {
            return _IBlogData.GetAll();
        }

        [HttpGet("{id}")]
        public Blog GetById(int? id)
        {
            return _IBlogData.GetById(id);
        }
    }
}