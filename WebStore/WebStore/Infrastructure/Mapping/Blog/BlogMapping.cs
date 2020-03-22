using WebStore.Domain.Entities;
using WebStore.ViewModels.Blog;
using System.Linq;

namespace WebStore.Infrastructure.Mapping.Blog
{
    public static class BlogMapping
    {
        public static BlogViewModel ToView(this Domain.Entities.Blog p)
        {

            return p == null ? null :
                new BlogViewModel
                {
                    Id = p.Id,
                    Author = p.Author,
                    BlogComments = p.BlogComments.Select(x => x.ToView()).ToList(),//.AsEnumerable(),
                    BlogRatings = p.BlogRatings.Select(x => x.ToView()).ToList(),//.AsEnumerable(),
                    BlogResponses = p.BlogResponses.Select(x => x.ToView()).ToList(),//.AsEnumerable(),
                    CreateDate = p.CreateDate,
                    Order = p.Order,
                    Text = p.Text,
                    ImageUrl = p.ImageUrl,
                    Title = p.Title
                };
        }

        // public static IEnumerable<ProductViewModel> ToView(this IEnumerable<Product> p) => p.Select(ToView);
    }
}
