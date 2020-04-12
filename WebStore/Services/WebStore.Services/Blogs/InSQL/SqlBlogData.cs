using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Entities.Blogs;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Blogs.InSQL
{
    /// <summary>
    /// Работа с базой данных по извлечению данных о Блогах
    /// </summary>
    public class SqlBlogData : IBlogData
    {

        public readonly WebStoreDB _db;

        public SqlBlogData(WebStoreDB db) => _db = db;

        public IEnumerable<Blog> GetAll()
        {
            var blogs = _db.Blogs
                    .Include(x => x.BlogComments)
                    .Include(x => x.User)
                    .ToList();
            return blogs;
        }

        public Blog GetById(int? Id)
        {
            if (Id == null)
                Id = _db.Blogs.Max(x => x.Id);

            var blog = _db.Blogs
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == Id);

            blog.BlogComments = _GetBlogComments(blog.Id);
            blog.BlogRatings = _GetBlogRatings(blog.Id);
            blog.BlogResponses = _GetResponses(blog.Id);

            return blog;
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
