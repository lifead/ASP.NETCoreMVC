using System;
using System.Collections.Generic;
using WebStore.Domain.Entities.Blog;
using WebStore.Domain.Entities.Identity;
using WebStore.Domain.Entities.Products;
using WebStore.Domain.Models;

namespace WebStore.Services.Data
{
    public class TestData
    {
        public static List<Employee> Employees { get; } = new List<Employee>
        {
                 new Employee(){ Id = 1, Age = 23, Department="Отдел № 1", Email="ges@example.com", SurName = "Гусев", FirstName = "Ефрем", Patronymic = "Степановна"       ,BirthDay = new DateTime(2000,01,21), DateOfEmployment = new DateTime(2020,03,01)}
                ,new Employee(){ Id = 2, Age = 34, Department="Отдел № 1", Email="akp@example.com", SurName = "Акимова ", FirstName = "Кристина ", Patronymic = "Петрович"  ,BirthDay = new DateTime(2000,04,14), DateOfEmployment = new DateTime(2020,03,02)}
                ,new Employee(){ Id = 3, Age = 45, Department="Отдел № 2", Email="jvd@example.com", SurName = "Жгулёв", FirstName = "Владилен", Patronymic = "Дмитриевич"   ,BirthDay = new DateTime(2000,02,27), DateOfEmployment = new DateTime(2020,02,04)}
                ,new Employee(){ Id = 4, Age = 32, Department="Отдел № 3", Email="snf@example.com", SurName = "Сонина ", FirstName = "Надежда", Patronymic = "Феликсовна"   ,BirthDay = new DateTime(2000,05,05), DateOfEmployment = new DateTime(2020,02,09)}
        };
        public static IEnumerable<Brand> Brands { get; } = new[]
        {
            new Brand { Id = 1, Name = "Acne", Order = 0 },
            new Brand { Id = 2, Name = "Grune Erde", Order = 1 },
            new Brand { Id = 3, Name = "Albiro", Order = 2 },
            new Brand { Id = 4, Name = "Ronhill", Order = 3 },
            new Brand { Id = 5, Name = "Oddmolly", Order = 4 },
            new Brand { Id = 6, Name = "Boudestijn", Order = 5 },
            new Brand { Id = 7, Name = "Rosch creative culture", Order = 6 },
        };

        public static IEnumerable<Section> Sections { get; } = new[]
       {
              new Section { Id = 1, Name = "Спорт", Order = 0 },
              new Section { Id = 2, Name = "Nike", Order = 0, ParentId = 1 },
              new Section { Id = 3, Name = "Under Armour", Order = 1, ParentId = 1 },
              new Section { Id = 4, Name = "Adidas", Order = 2, ParentId = 1 },
              new Section { Id = 5, Name = "Puma", Order = 3, ParentId = 1 },
              new Section { Id = 6, Name = "ASICS", Order = 4, ParentId = 1 },
              new Section { Id = 7, Name = "Для мужчин", Order = 1 },
              new Section { Id = 8, Name = "Fendi", Order = 0, ParentId = 7 },
              new Section { Id = 9, Name = "Guess", Order = 1, ParentId = 7 },
              new Section { Id = 10, Name = "Valentino", Order = 2, ParentId = 7 },
              new Section { Id = 11, Name = "Диор", Order = 3, ParentId = 7 },
              new Section { Id = 12, Name = "Версачи", Order = 4, ParentId = 7 },
              new Section { Id = 13, Name = "Армани", Order = 5, ParentId = 7 },
              new Section { Id = 14, Name = "Prada", Order = 6, ParentId = 7 },
              new Section { Id = 15, Name = "Дольче и Габбана", Order = 7, ParentId = 7 },
              new Section { Id = 16, Name = "Шанель", Order = 8, ParentId = 7 },
              new Section { Id = 17, Name = "Гуччи", Order = 9, ParentId = 7 },
              new Section { Id = 18, Name = "Для женщин", Order = 2 },
              new Section { Id = 19, Name = "Fendi", Order = 0, ParentId = 18 },
              new Section { Id = 20, Name = "Guess", Order = 1, ParentId = 18 },
              new Section { Id = 21, Name = "Valentino", Order = 2, ParentId = 18 },
              new Section { Id = 22, Name = "Dior", Order = 3, ParentId = 18 },
              new Section { Id = 23, Name = "Versace", Order = 4, ParentId = 18 },
              new Section { Id = 24, Name = "Для детей", Order = 3 },
              new Section { Id = 25, Name = "Мода", Order = 4 },
              new Section { Id = 26, Name = "Для дома", Order = 5 },
              new Section { Id = 27, Name = "Интерьер", Order = 6 },
              new Section { Id = 28, Name = "Одежда", Order = 7 },
              new Section { Id = 29, Name = "Сумки", Order = 8 },
              new Section { Id = 30, Name = "Обувь", Order = 9 },
        };

        public static IEnumerable<Product> Products { get; } = new[]
        {
            new Product { Id = 1, Name = "Белое платье", Price = 1025, ImageUrl = "product1.jpg", Order = 0, SectionId = 2, BrandId = 1 },
            new Product { Id = 2, Name = "Розовое платье", Price = 1025, ImageUrl = "product2.jpg", Order = 1, SectionId = 2, BrandId = 1 },
            new Product { Id = 3, Name = "Красное платье", Price = 1025, ImageUrl = "product3.jpg", Order = 2, SectionId = 2, BrandId = 1 },
            new Product { Id = 4, Name = "Джинсы", Price = 1025, ImageUrl = "product4.jpg", Order = 3, SectionId = 2, BrandId = 1 },
            new Product { Id = 5, Name = "Лёгкая майка", Price = 1025, ImageUrl = "product5.jpg", Order = 4, SectionId = 2, BrandId = 2 },
            new Product { Id = 6, Name = "Лёгкое голубое поло", Price = 1025, ImageUrl = "product6.jpg", Order = 5, SectionId = 2, BrandId = 1 },
            new Product { Id = 7, Name = "Платье белое", Price = 1025, ImageUrl = "product7.jpg", Order = 6, SectionId = 2, BrandId = 1 },
            new Product { Id = 8, Name = "Костюм кролика", Price = 1025, ImageUrl = "product8.jpg", Order = 7, SectionId = 25, BrandId = 1 },
            new Product { Id = 9, Name = "Красное китайское платье", Price = 1025, ImageUrl = "product9.jpg", Order = 8, SectionId = 25, BrandId = 1 },
            new Product { Id = 10, Name = "Женские джинсы", Price = 1025, ImageUrl = "product10.jpg", Order = 9, SectionId = 25, BrandId = 3 },
            new Product { Id = 11, Name = "Джинсы женские", Price = 1025, ImageUrl = "product11.jpg", Order = 10, SectionId = 25, BrandId = 3 },
            new Product { Id = 12, Name = "Летний костюм", Price = 1025, ImageUrl = "product12.jpg", Order = 11, SectionId = 25, BrandId = 3 },
        };


        private static readonly DateTime crDt = new DateTime(2013, 12, 05, 01, 33, 00);
        private static readonly string name = "GIRLS PINK T SHIRT ARRIVED IN STORE";
        private static readonly string text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.";
        private static readonly string textComment = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";

        public static IEnumerable<Blog> Blogs { get; } = new[]
        {
            new Blog{ Id = 1, UserId="79a576b1-80ca-482a-bb37-03d002f4c088", Author = "Mac Doe", ImageUrl = "blog-one.jpg", CreateDate = crDt, Title = name, Order = 1, Text = text},
            new Blog{ Id = 2, UserId="79a576b1-80ca-482a-bb37-03d002f4c088", Author = "Mac Doe", ImageUrl = "blog-two.jpg", CreateDate = crDt, Title = name, Order = 1, Text = text},
            new Blog{ Id = 3, UserId="79a576b1-80ca-482a-bb37-03d002f4c088", Author = "Mac Doe", ImageUrl = "blog-three.jpg", CreateDate = crDt, Title = name, Order = 1, Text = text},
        };

        public static IEnumerable<BlogComment> BlogComments { get; } = new[]
        {
            new BlogComment{
                Id = 1,
                Author = "Annie Davis",
                BlogId=1,
                Comment = textComment,
                CreateDate = crDt,
                Order=1,
                UserId="f7c34c09-f8c3-4821-a483-9113e9fe8b43"
            }
        };

        public static IEnumerable<BlogResponse> BlogResponses { get; } = new[]
        {
            new BlogResponse {Id = 1, UserId = "0f805845-bdb9-41c3-ad54-4bdd5787c3e8", ImageUrl = "man-four.jpg", Author = "JANIS GALLAGHER",BlogId = 1,BlogResponseId = null,CreateDate = crDt,Order = 1,ResponseText = textComment},
            new BlogResponse {Id = 2, UserId = "0f805845-bdb9-41c3-ad54-4bdd5787c3e8", ImageUrl = "man-one.jpg", Author = "JANIS GALLAGHER",BlogId = 1,BlogResponseId = 1,CreateDate = crDt,Order = 1,ResponseText = textComment},
            new BlogResponse {Id = 3, UserId = "0f805845-bdb9-41c3-ad54-4bdd5787c3e8", ImageUrl = "man-three.jpg", Author = "JANIS GALLAGHER",BlogId = 1,BlogResponseId = null,CreateDate = crDt,Order = 1,ResponseText = textComment}
        };

        public static IEnumerable<BlogRating> BlogRatings { get; } = new[]
        {
            new BlogRating{ Id = 1, UserId = "0f805845-bdb9-41c3-ad54-4bdd5787c3e8", BlogId = 1, Rating = 5, CreateDate = crDt},
            new BlogRating{ Id = 2, UserId = "79a576b1-80ca-482a-bb37-03d002f4c088", BlogId = 1, Rating = 4, CreateDate = crDt},
            new BlogRating{ Id = 3, UserId = "0f805845-bdb9-41c3-ad54-4bdd5787c3e8", BlogId = 2, Rating = 5, CreateDate = crDt},
            new BlogRating{ Id = 4, UserId = "79a576b1-80ca-482a-bb37-03d002f4c088", BlogId = 2, Rating = 4, CreateDate = crDt},
            new BlogRating{ Id = 5, UserId = "0f805845-bdb9-41c3-ad54-4bdd5787c3e8", BlogId = 3, Rating = 5, CreateDate = crDt},
            new BlogRating{ Id = 6, UserId = "79a576b1-80ca-482a-bb37-03d002f4c088", BlogId = 3, Rating = 4, CreateDate = crDt},
        };
    }
};

