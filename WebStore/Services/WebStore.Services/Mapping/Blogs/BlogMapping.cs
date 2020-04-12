using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.DTO.Blogs;
using WebStore.Domain.Entities.Blogs;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.ViewModels.Blog;

namespace WebStore.Services.Mapping.Blogs
{
    public static class BlogMapping
    {
        public static BlogViewModel ToView(this Blog p)
        {

            return p == null ? null :
                new BlogViewModel
                {
                    Id = p.Id,
                    BlogComments = p.BlogComments?.Select(x => x.ToView()).ToList() ?? new List<BlogCommentViewModel>(),
                    BlogRatings = p.BlogRatings?.Select(x => x.ToView()).ToList() ?? new List<BlogRatingViewModel>(),
                    BlogResponses = p.BlogResponses?.Select(x => x.ToView()).ToList() ?? new List<BlogResponseViewModel>(),
                    CreateDate = p.CreateDate,
                    Text = p.Text,
                    ImageUrl = p.ImageUrl,
                    Title = p.Title,
                    Author = p.User?.ToString() ?? "---"
                };
        }

        public static BlogDTO ToDTO(this Blog p) => p == null ? null :
                new BlogDTO
                {
                    Id = p.Id,
                    BlogComments = p.BlogComments?.Select(x => x.ToDTO()).ToList() ?? new List<BlogCommentDTO>(),
                    BlogRatings = p.BlogRatings?.Select(x => x.ToDTO()).ToList() ?? new List<BlogRatingDTO>(),
                    BlogResponses = p.BlogResponses?.Select(x => x.ToDTO()).ToList() ?? new List<BlogResponseDTO>(),
                    CreateDate = p.CreateDate,
                    Text = p.Text,
                    ImageUrl = p.ImageUrl,
                    Title = p.Title,
                    User = new User()
                    {
                        Id = p.User.Id,
                        Surname = p.User.Surname,
                        FirstName = p.User.FirstName,
                        UserName = p.User.UserName
                    }
                };

        public static Blog FromDTO(this BlogDTO p) => p == null ? null :
          new Blog
          {
              Id = p.Id,
              BlogComments = p.BlogComments?.Select(x => x.FromDTO()).ToList() ?? new List<BlogComment>(),
              BlogRatings = p.BlogRatings?.Select(x => x.FromDTO()).ToList() ?? new List<BlogRating>(),
              BlogResponses = p.BlogResponses?.Select(x => x.FromDTO()).ToList() ?? new List<BlogResponse>(),
              CreateDate = p.CreateDate,
              Text = p.Text,
              ImageUrl = p.ImageUrl,
              Title = p.Title,
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
