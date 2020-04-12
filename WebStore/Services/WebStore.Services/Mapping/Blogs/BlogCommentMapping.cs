using WebStore.Domain.DTO.Blogs;
using WebStore.Domain.Entities.Blogs;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.ViewModels.Blog;


namespace WebStore.Services.Mapping.Blogs
{
    public static class BlogCommentMapping
    {
        public static BlogCommentViewModel ToView(this BlogComment p) => new BlogCommentViewModel
        {
            Id = p.Id,
            BlogId = p.BlogId,
            Comment = p.Comment,
            CreateDate = p.CreateDate,
            UserId = p.UserId,
            Author = p.User?.ToString() ?? "****"
        };


        public static BlogCommentDTO ToDTO(this BlogComment p) => new BlogCommentDTO
        {
            Id = p.Id,
            BlogId = p.BlogId,
            Comment = p.Comment,
            CreateDate = p.CreateDate,
            UserId = p.UserId,
            User = new User()
            {
                Id = p.User.Id,
                Surname = p.User.Surname,
                FirstName = p.User.FirstName,
                UserName = p.User.UserName
            }
        };

        public static BlogComment FromDTO(this BlogCommentDTO p) => new BlogComment
        {
            Id = p.Id,
            BlogId = p.BlogId,
            Comment = p.Comment,
            CreateDate = p.CreateDate,
            UserId = p.UserId,
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
