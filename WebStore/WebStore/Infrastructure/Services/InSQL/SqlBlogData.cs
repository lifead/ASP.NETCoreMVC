using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services.InSQL
{
    /// <summary>
    /// Работа с базой данных по извлечению данных о Блогах
    /// </summary>
    public class SqlBlogData : IBlogData
    {

        public readonly WebStoreDB _db;

        public SqlBlogData(WebStoreDB db) => _db = db;

        public IEnumerable<Blog> GetAll() => _db.Blogs.AsEnumerable();

        public Blog GetById(int Id) => _db.Blogs.FirstOrDefault(x=>x.Id == Id);
        
    }
}
