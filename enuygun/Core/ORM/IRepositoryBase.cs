using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.ORM
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity Entity);
        void Delete(TEntity Entity);
        IEnumerable<TEntity> ToList(Expression<Func<TEntity, bool>> Filter = null);
        TEntity GetById(int id);
        int AddBulk(IList<TEntity> entities);
    }
}
