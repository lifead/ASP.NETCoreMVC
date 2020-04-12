using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.ViewModels.Blog;

namespace WebStore.Services.Mapping.Blogs
{
    public static class BlogMapping
    {
        public static BlogViewModel ToView(this Domain.Entities.Blogs.Blog p)
        {

            return p == null ? null :
                new BlogViewModel
                {
                    Id = p.Id,
                    BlogComments = p.BlogComments?.Select(x => x.ToView()).ToList() ?? new List<BlogCommentViewModel>(),
                    BlogRatings = p.BlogRatings?.Select(x => x.ToView()).ToList() ?? new List<BlogRatingViewModel>(),
                    BlogResponses = p.BlogResponses?.Select(x => x.ToView()).ToList() ?? new List<BlogResponseViewModel>(),
                    CreateDate = p.CreateDate,
                    Order = p.Order,
                    Text = p.Text,
                    ImageUrl = p.ImageUrl,
                    Title = p.Title,
                    Author = p.User?.ToString() ?? "---"
                };
        }

        // public static IEnumerable<ProductViewModel> ToView(this IEnumerable<Product> p) => p.Select(ToView);
    }
}
