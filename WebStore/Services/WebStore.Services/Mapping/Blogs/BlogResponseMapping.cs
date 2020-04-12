﻿using WebStore.Domain.Entities.Blogs;
using WebStore.Domain.ViewModels.Blog;

namespace WebStore.Services.Mapping.Blogs
{
    public static class BlogResponseMapping
    {
        public static BlogResponseViewModel ToView(this BlogResponse p) => new BlogResponseViewModel
        {
            Id = p.Id,
            BlogId = p.BlogId,
            CreateDate = p.CreateDate,
            UserId = p.UserId,
            BlogResponseId = p.BlogResponseId,
            ResponseText = p.ResponseText,
            ImageUrl = p.ImageUrl,
            Author = p.User?.ToString() ?? "&&&&"
            //Blog = p.Blog.ToView(),
            //ParentBlogResponse = p.ParentBlogResponse.ToView()
        };
    }
}
