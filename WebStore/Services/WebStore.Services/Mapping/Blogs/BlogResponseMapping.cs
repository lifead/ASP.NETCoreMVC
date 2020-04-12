using WebStore.Domain.DTO.Blogs;
using WebStore.Domain.Entities.Blogs;
using WebStore.Domain.Entities.Identity;
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
        };

        public static BlogResponseDTO ToDTO(this BlogResponse p) => new BlogResponseDTO
        {
            Id = p.Id,
            BlogId = p.BlogId,
            CreateDate = p.CreateDate,
            UserId = p.UserId,
            BlogResponseId = p.BlogResponseId,
            ResponseText = p.ResponseText,
            ImageUrl = p.ImageUrl,
            User = new User()
            {
                Id = p.User.Id,
                Surname = p.User.Surname,
                FirstName = p.User.FirstName,
                UserName = p.User.UserName
            }
        };


        public static BlogResponse FromDTO(this BlogResponseDTO p) => new BlogResponse
        {
            Id = p.Id,
            BlogId = p.BlogId,
            CreateDate = p.CreateDate,
            UserId = p.UserId,
            BlogResponseId = p.BlogResponseId,
            ResponseText = p.ResponseText,
            ImageUrl = p.ImageUrl,
            User = new User()
            {
                Id = p.User.Id,
                Surname = p.User.Surname,
                FirstName = p.User.FirstName,
                UserName = p.User.UserName
            }
        };
    }
}
