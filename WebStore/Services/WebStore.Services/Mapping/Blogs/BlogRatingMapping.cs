using WebStore.Domain.Entities.Blogs;
using WebStore.Domain.ViewModels.Blog;


namespace WebStore.Services.Mapping.Blogs
{
    public static class BlogRatingMapping
    {
        public static BlogRatingViewModel ToView(this BlogRating p) => new BlogRatingViewModel
        {
            Id = p.Id,
            BlogId = p.BlogId,
            CreateDate = p.CreateDate,
            UserId = p.UserId,
            Rating = p.Rating,
            //Blog = p.Blog.ToView()
        };
    }
}
