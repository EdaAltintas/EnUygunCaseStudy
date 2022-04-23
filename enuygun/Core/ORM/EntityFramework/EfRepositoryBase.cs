using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.ORM.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext>
       : IRepositoryBase<TEntity>
       where TEntity : class, new()
       where TContext : DbContext, new()
    {
        public void Add(TEntity Entity)
        {
            using (var context = new TContext())
            {
                context.Add(Entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity Entity)
        {
            using (var context = new TContext())
            {
                context.Remove(Entity);
                context.SaveChanges();
            }
        }


        public IEnumerable<TEntity> ToList(Expression<Func<TEntity, bool>> Filter = null)
        {
            using (var context = new TContext())
            {
                var list = Filter == null ? context.Set<TEntity>().ToList() :
                     context.Set<TEntity>().Where(Filter).ToList();
                return list;
            }
        }

        public TEntity GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(id);
            }
        }

        public TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).FirstOrDefault();
            }
        }

        public int AddBulk(IList<TEntity> entities)
        {
            using(var context= new TContext())
            {
                context.AddRange(entities);
                return context.SaveChanges();
            }
        }
    }
}
