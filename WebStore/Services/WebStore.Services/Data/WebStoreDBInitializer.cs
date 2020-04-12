using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Services.Data
{
    public class WebStoreDBInitializer
    {
        private readonly WebStoreDB _db;
        private readonly UserManager<User> _UserManager;
        private readonly RoleManager<Role> _RoleManager;

        public WebStoreDBInitializer(WebStoreDB db, UserManager<User> UserManager, RoleManager<Role> RoleManager)
        {
            _db = db;
            _UserManager = UserManager;
            _RoleManager = RoleManager;
        }

        public void Initialize() => InitializeAsync().Wait();

        public async Task InitializeAsync()
        {
            await _db.Database.MigrateAsync().ConfigureAwait(false);

            //Настраиваем таблицы пользователей и ролей
            await InitializeIdentityAsync().ConfigureAwait(false);

            //Настраиваем таблицы продуктов
            await InitializeProductAsync().ConfigureAwait(false);

            //Настраиваем таблицы блогов
            await InitializeBlogAsync().ConfigureAwait(false);



        }

        #region InitializeIdentityAsync
        /// <summary>
        /// InitializeIdentityAsync - Добавление пользователей и ролей "по умолчнию"
        /// </summary>
        /// <returns></returns>
        private async Task InitializeIdentityAsync()
        {
            if (!await _RoleManager.RoleExistsAsync(Role.Administrator))
                await _RoleManager.CreateAsync(new Role { Name = Role.Administrator });

            if (!await _RoleManager.RoleExistsAsync(Role.User))
                await _RoleManager.CreateAsync(new Role { Name = Role.User });

            if (await _UserManager.FindByNameAsync(User.Administrator) is null)
            {
                var admin = new User
                {
                    UserName = User.Administrator,
                    //Email = "amin@server.com"
                };

                var create_result = await _UserManager.CreateAsync(admin, User.AdminDefaultPassword);
                if (create_result.Succeeded)
                    await _UserManager.AddToRoleAsync(admin, Role.Administrator);
                else
                {
                    var errors = create_result.Errors.Select(error => error.Description);
                    throw new InvalidOperationException($"Ошибка при создании пользователя - Администратора: {string.Join(", ", errors)}");
                }
            }

            #region Добавление пользователей для работы раздела Блог
            if (await _UserManager.FindByNameAsync("JanisGallagher") is null)
            {
                var user1 = new User
                {
                    Id="0f805845-bdb9-41c3-ad54-4bdd5787c3e8", 
                    UserName="JanisGallagher",
                    FirstName="Janis",
                    Surname="Gallagher"
                };
                var create_result1 = await _UserManager.CreateAsync(user1, Guid.NewGuid().ToString());

                var user2 = new User
                {
                    Id = "79a576b1-80ca-482a-bb37-03d002f4c088",
                    UserName = "MacDoe",
                    FirstName = "Mac",
                    Surname = "Doe"
                };
                var create_result2 = await _UserManager.CreateAsync(user2, Guid.NewGuid().ToString());

                var user3 = new User
                {
                    Id = "f7c34c09-f8c3-4821-a483-9113e9fe8b43",
                    UserName = "AnnieDavis",
                    FirstName = "Annie",
                    Surname = "Davis"
                };
                var create_result3 = await _UserManager.CreateAsync(user3, Guid.NewGuid().ToString());
                #endregion

            }

        }
        #endregion

        #region InitializeBlogAsync - Добавление блогов "по умолчнию"
        /// <summary>
        /// InitializeBlogAsync - Добавление блогов "по умолчнию"
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private async Task InitializeBlogAsync()
        {
            var db = _db.Database;

            if (!await _db.Blogs.AnyAsync())
            {
                using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
                {
                    await _db.Blogs.AddRangeAsync(TestData.Blogs).ConfigureAwait(false);

                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Blogs] ON");
                    await _db.SaveChangesAsync().ConfigureAwait(false);
                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Blogs] OFF");

                    await transaction.CommitAsync().ConfigureAwait(false);
                }

                using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
                {
                    await _db.BlogRatings.AddRangeAsync(TestData.BlogRatings).ConfigureAwait(false);

                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[BlogRatings] ON");
                    await _db.SaveChangesAsync().ConfigureAwait(false);
                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[BlogRatings] OFF");

                    await transaction.CommitAsync().ConfigureAwait(false);
                }

                using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
                {
                    await _db.BlogComments.AddRangeAsync(TestData.BlogComments).ConfigureAwait(false);

                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[BlogComments] ON");
                    await _db.SaveChangesAsync().ConfigureAwait(false);
                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[BlogComments] OFF");

                    await transaction.CommitAsync().ConfigureAwait(false);
                }

                using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
                {
                    await _db.BlogResponses.AddRangeAsync(TestData.BlogResponses).ConfigureAwait(false);

                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[BlogResponses] ON");
                    await _db.SaveChangesAsync().ConfigureAwait(false);
                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[BlogResponses] OFF");

                    await transaction.CommitAsync().ConfigureAwait(false);
                }
            }
        }
        #endregion

        #region InitializeProductAsync - Добавление товаров "по умолчнию"
        /// <summary>
        /// InitializeProductAsync - Добавление товаров "по умолчнию"
        /// </summary>
        /// <returns></returns>
        private async Task InitializeProductAsync()
        {
            var db = _db.Database;

            //Настраиваем таблицы продуктов
            if (!await _db.Products.AnyAsync())
            {
                using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
                {
                    await _db.Sections.AddRangeAsync(TestData.Sections).ConfigureAwait(false);

                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Sections] ON");
                    await _db.SaveChangesAsync().ConfigureAwait(false);
                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Sections] OFF");

                    await transaction.CommitAsync().ConfigureAwait(false);
                }

                using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
                {
                    await _db.Brands.AddRangeAsync(TestData.Brands).ConfigureAwait(false);

                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Brands] ON");
                    await _db.SaveChangesAsync().ConfigureAwait(false);
                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Brands] OFF");

                    await transaction.CommitAsync().ConfigureAwait(false);
                }

                using (var transaction = await db.BeginTransactionAsync().ConfigureAwait(false))
                {
                    await _db.Products.AddRangeAsync(TestData.Products).ConfigureAwait(false);

                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Products] ON");
                    await _db.SaveChangesAsync().ConfigureAwait(false);
                    await db.ExecuteSqlRawAsync("SET IDENTITY_INSERT [dbo].[Products] OFF");

                    await transaction.CommitAsync().ConfigureAwait(false);
                }
            }
        }
        #endregion
    }
}
