using WebStore.Domain.Entities.Blog;
using WebStore.Domain.ViewModels.Blog;


namespace WebStore.Services.Mapping.Blogs
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
