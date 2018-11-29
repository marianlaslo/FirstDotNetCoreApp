using System;
using System.Linq;
using System.Linq.Expressions;

namespace FirstDotNetCoreApp.DataAccess.Repositories.Abstractions
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected MyDbContext MyDbContext { get; }

        protected RepositoryBase(MyDbContext myDbContext)
        {
            MyDbContext = myDbContext;
        }

        public IQueryable<T> FindAll()
        {
            return MyDbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return MyDbContext.Set<T>().Where(expression);
        }

        public T Create(T entity)
        {
            MyDbContext.Set<T>().Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            MyDbContext.Set<T>().Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            MyDbContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            MyDbContext.SaveChanges();
        }
    }
}
