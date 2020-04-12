using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Clients.Base;
using WebStore.Domain;
using WebStore.Domain.DTO.Blogs;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Blogs
{
    public class BlogsClient : BaseClient, IBlogData
    {
        public BlogsClient(IConfiguration Configuration) : base(Configuration, WebAPI.Blogs) { }

        public IEnumerable<BlogDTO> GetAll() => Get<List<BlogDTO>>(_ServiceAddress);

        public BlogDTO GetById(int? id) => Get<BlogDTO>($"{_ServiceAddress}/{id}");
    }
}
