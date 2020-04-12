﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Entities.Blogs;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Blogs.InSQL
{
    /// <summary>
    /// Работа с базой данных по извлечению данных о Блогах
    /// </summary>
    public class SqlBlogData : IBlogData
    {

        public readonly WebStoreDB _db;

        public SqlBlogData(WebStoreDB db) => _db = db;

        public IEnumerable<Blog> GetAll() => _db.Blogs
            .Include(x => x.BlogComments)
            .Include(x => x.BlogRatings)
            .Include(x => x.BlogResponses)
            .Include(x => x.User)
            .AsEnumerable();

        public Blog GetById(int? Id)
        {
            if (Id == null)
                Id = _db.Blogs.Max(x => x.Id);

            return _db.Blogs
                .Include(x => x.BlogComments)
                .Include(x => x.BlogRatings)
                .Include(x => x.BlogResponses)
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == Id);
        }
    }
}
