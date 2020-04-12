using WebStore.Domain.DTO.Blogs;
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
            Rating = p.Rating
        };
        public static BlogRatingDTO ToDTO(this BlogRating p) => new BlogRatingDTO
        {
            Id = p.Id,
            BlogId = p.BlogId,
            CreateDate = p.CreateDate,
            UserId = p.UserId,
            Rating = p.Rating
        };

        public static BlogRating FromDTO(this BlogRatingDTO p) => new BlogRating
        {
            Id = p.Id,
            BlogId = p.BlogId,
            CreateDate = p.CreateDate,
            UserId = p.UserId,
            Rating = p.Rating
        };



    }
}
