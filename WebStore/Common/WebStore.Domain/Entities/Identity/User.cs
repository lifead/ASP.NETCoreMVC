using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using WebStore.Domain.Entities.Blogs;

namespace WebStore.Domain.Entities.Identity
{
    /// <summary>
    /// Пользователь (переопределенная сущность)
    /// </summary>
    public class User : IdentityUser
    {
        public const string Administrator = "Admin";
        public const string AdminDefaultPassword = "AdminPassword";

        public string FirstName { get; set; }
        public string Surname { get; set; }


        /// <summary>Список блогов</summary>
        public virtual ICollection<Blog> Blogs { get; set; }

        /// <summary>Список комментариев блога</summary>
        public virtual ICollection<BlogComment> BlogComments { get; set; }

        /// <summary>Список рейтингов блога</summary>
        public virtual ICollection<BlogRating> BlogRatings { get; set; }

        /// <summary>Список отзывов на блог</summary>
        public virtual ICollection<BlogResponse> GetBlogResponses { get; set; }
        
        
        public override string ToString()
        {
            return !string.IsNullOrEmpty(FirstName) ? $"{FirstName} {Surname ?? ""}" : $"UserName";
        }
    }
}
