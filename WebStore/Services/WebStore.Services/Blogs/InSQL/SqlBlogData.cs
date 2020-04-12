using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.DTO.Blogs;
using WebStore.Domain.Entities.Blogs;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping.Blogs;

namespace WebStore.Services.Blogs.InSQL
{
    /// <summary>
    /// Работа с базой данных по извлечению данных о Блогах
    /// </summary>
    public class SqlBlogData : IBlogData
    {

        public readonly WebStoreDB _db;

        public SqlBlogData(WebStoreDB db) => _db = db;

        public IEnumerable<BlogDTO> GetAll()
        {
            var blogs = _db.Blogs
                    //.Include(x => x.BlogComments)
                    .Include(x => x.User)
                    .Select(x => x.ToDTO())
                    .ToList();
            return blogs;
        }

        public BlogDTO GetById(int? Id)
        {
            if (Id == null)
                Id = _db.Blogs.Max(x => x.Id);

            var blog = _db.Blogs
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == Id);

            blog.BlogComments = _GetBlogComments(blog.Id);
            blog.BlogRatings = _GetBlogRatings(blog.Id);
            blog.BlogResponses = _GetResponses(blog.Id);

            return blog.ToDTO();
        }

        private List<BlogRating> _GetBlogRatings(int BlogId)
        {
            return _db.BlogRatings.Include(x => x.User).Where(x => x.BlogId == BlogId).ToList();
        }

        private List<BlogComment> _GetBlogComments(int BlogId)
        {
            return _db.BlogComments.Include(x => x.User).Where(x => x.BlogId == BlogId).ToList();
        }

        private List<BlogResponse> _GetResponses(int BlogId)
        {
            return _db.BlogResponses.Include(x => x.User).Where(x => x.BlogId == BlogId).ToList();
        }



    }
}
