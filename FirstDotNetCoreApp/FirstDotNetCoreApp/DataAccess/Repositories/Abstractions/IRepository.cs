﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace FirstDotNetCoreApp.DataAccess.Repositories.Abstractions
{
    public interface IRepository<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        T GetById<TId>(TId id);

        T Create(T entity);

        T Update(T entity, params string[] properties);

        void Delete<TId>(TId id);

        void Save();
    }
}
