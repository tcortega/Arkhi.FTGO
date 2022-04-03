using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Arkhi.FTGO.Libs.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        void Add(ICollection<T> entity);
        void Update(T entity);
        void Remove(T entity);
        T Find(int id);
        T Find(Expression<Func<T, bool>> expression);
        IQueryable<T> Query();
        void Commit();
    }
}