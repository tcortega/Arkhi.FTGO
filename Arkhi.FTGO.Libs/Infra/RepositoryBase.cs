using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Arkhi.FTGO.Libs.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Arkhi.FTGO.Libs.Infra
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DbContext Context;

        public RepositoryBase(DbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Add(ICollection<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public T Find(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Find(expression);
        }

        public IQueryable<T> Query()
        {
            return Context.Set<T>().AsQueryable();
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}