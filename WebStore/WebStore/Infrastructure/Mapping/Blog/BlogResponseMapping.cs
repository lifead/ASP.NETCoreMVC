﻿using WebStore.Domain.Entities.Blog;
using WebStore.ViewModels.Blog;

namespace WebStore.Infrastructure.Mapping.Blog
{
    public static class BlogResponseMapping
    {
        public static BlogResponseViewModel ToView(this BlogResponse p) => new BlogResponseViewModel
        {
            Id = p.Id,
            BlogId = p.BlogId,
            Author = p.Author,
            CreateDate = p.CreateDate,
            UserId = p.UserId,
            BlogResponseId = p.BlogResponseId,
            Order = p.Order,
            ResponseText = p.ResponseText,
            ImageUrl = p.ImageUrl
            //Blog = p.Blog.ToView(),
            //ParentBlogResponse = p.ParentBlogResponse.ToView()
        };
    }
}
