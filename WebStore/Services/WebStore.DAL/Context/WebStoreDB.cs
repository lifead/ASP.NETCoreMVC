using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Domain.Entities.Blog;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Entities.Orders;
using WebStore.Domain.Entities.Products;

namespace WebStore.DAL.Context
{
    public class WebStoreDB : IdentityDbContext<User, Role, string>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogResponse> BlogResponses { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogRating> BlogRatings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        public WebStoreDB(DbContextOptions<WebStoreDB> Options)
            :base(Options)
        { }
    }
}
