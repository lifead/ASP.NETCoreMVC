using Microsoft.EntityFrameworkCore;
using WebStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Blog;

namespace WebStore.DAL.Context
{
    public class WebStoreDB : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogResponse> BlogResponses { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogRating> BlogRatings { get; set; }

        public WebStoreDB(DbContextOptions<WebStoreDB> Options)
            :base(Options)
        { }
    }
}
