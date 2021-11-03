using ApiRest.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiRest.DataAccess
{
    public class DBContext<T> : IDbContext<T> where T : class, IEntity
    {

        DbSet<T> _items;

        ApiDbContext _ctx;
        public DBContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            _items = ctx.Set<T>();

        }

        public void Delete(int id)
        {
           
        }

        public IList<T> GetAll()
        {
            return _items.ToList();
        }



        public T GetById(int id)
        {
            return _items.Where(i=> i.Id.Equals(id)).FirstOrDefault();
        }

        public T Save(T entity)
        {
            _items.Add(entity);
            _ctx.SaveChanges();

            return entity;

        }
    }
}
