using System;
using FirstDotNetCoreApp.DataAccess;
using FirstDotNetCoreApp.DataAccess.Repositories;
using FirstDotNetCoreApp.DataAccess.Repositories.Abstractions;
using FirstDotNetCoreApp.Models;
using FirstDotNetCoreApp.Models.Abstractions;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FirstDotNetCoreApp.Tests
{
    public class BaseRepositoryTests
    {
        [Fact]
        public void Create_CreateEntityAndSave_EntityIsCreated()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_FirstDotNetCoreApp")
                .Options;
            var entity = new Product { Id = 1 };

            //act
            Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                repo.Create(entity);
                repo.Save();
            });
            var savedEntity = Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                return repo.GetById(entity.Id);
            });

            //assert
            savedEntity.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public void Create_CreateEntityThatExists_EntityIsNotCreated()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_FirstDotNetCoreApp")
                .Options;

            var entity = new Product { Id = 1 };

            Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                repo.Create(entity);
                repo.Save();
            });

            Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                repo.Create(entity);
                repo.Save();
            });
        }
    }

    public static class Disposable
    {
        public static TResult Using<TDisposable, TResult>
        (
            Func<TDisposable> factory,
            Func<TDisposable, TResult> fn)
            where TDisposable : IDisposable
        {
            using (var disposable = factory())
            {
                return fn(disposable);
            }
        }

        public static void Using<TDisposable>
        (
            Func<TDisposable> factory,
            Action<TDisposable> fn)
            where TDisposable : IDisposable
        {
            using (var disposable = factory())
            {
                fn(disposable);
            }
        }
    }

    //Disposable.Using(() => new MyDbContext(options), context =>
    //{
    //var repo = new ProductRepository(context);
    //repo.Create(entity);
    //repo.Save();
    //});
}
