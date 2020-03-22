using WebStore.Domain.Entities;
using WebStore.ViewModels.Blog;

namespace WebStore.Infrastructure.Mapping.Blog
{
    public static class BlogCommentMapping
    {
        public static BlogCommentViewModel ToView(this BlogComment p) => new BlogCommentViewModel
        {
            Id = p.Id,
            Author = p.Author,
            BlogId = p.BlogId,
            Comment = p.Comment,
            CreateDate = p.CreateDate,
            Order = p.Order,
            UserId = p.UserId,
            //Blog = p.Blog.ToView()
        };
    }
}
