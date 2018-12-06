using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstDotNetCoreApp.DataAccess.Repositories.Abstractions
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        T GetById<TId>(TId id);

        T Create(T entity);

        T Update(T entity);

        void Delete<TId>(TId id);

        void Save();
    }
}
