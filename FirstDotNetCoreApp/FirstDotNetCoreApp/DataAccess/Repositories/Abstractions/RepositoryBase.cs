using System;
using System.Linq;
using System.Linq.Expressions;
using FirstDotNetCoreApp.Models.Abstractions;
using Microsoft.EntityFrameworkCore;

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

        public T GetById<TId>(TId id)
        {
            var entity = MyDbContext.Set<T>().Find(id);
            return entity;
        }

        public T Create(T entity)
        {
            MyDbContext.Set<T>().Add(entity);
            return entity;
        }

        public T Update(T entity, params string[] properties)
        {
            foreach (var column in properties)
            {
                MyDbContext.Entry(entity).Property(column).IsModified = true;
            }

            return entity;
        }

        public void Delete<TId>(TId id)
        {
            var instance = Activator.CreateInstance<T>();
            var entity = (IEntity<TId>) instance;
            entity.Id = id;
            var castedEntity = (T) entity;
            MyDbContext.Set<T>().Attach(castedEntity);
            MyDbContext.Set<T>().Remove(castedEntity);
        }

        public void Save()
        {
            MyDbContext.SaveChanges();
        }
    }
}
