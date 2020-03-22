using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Blog;
using WebStore.ViewModels.Blog;

namespace WebStore.Infrastructure.Mapping.Blog
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
