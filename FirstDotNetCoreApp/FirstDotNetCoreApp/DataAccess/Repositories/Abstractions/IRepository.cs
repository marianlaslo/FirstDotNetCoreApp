using System;
using System.Linq;
using System.Linq.Expressions;

namespace FirstDotNetCoreApp.DataAccess.Repositories.Abstractions
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        T GetById<V>(V id);

        T Create(T entity);

        T Update(T entity);

        void Delete(T entity);

        void Save();
    }
}
