using System;
using System.Linq;
using FirstDotNetCoreApp.DataAccess;
using FirstDotNetCoreApp.DataAccess.Repositories;
using FirstDotNetCoreApp.Extensions;
using FirstDotNetCoreApp.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FirstDotNetCoreApp.Tests
{
    public class RepositoryBaseTests
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
            // arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_FirstDotNetCoreApp")
                .Options;
            var entity = new Product { Id = 2 };

            // act
            Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                repo.Create(entity);
                repo.Save();
            });
            Action action = () => Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                repo.Create(entity);
                repo.Save();
            });

            //assert
            action.Should().Throw<ArgumentException>(); ;
        }

        [Fact]
        public void GetById_EntityWithIdExists_EntityWithIdIsReturned()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_FirstDotNetCoreApp")
                .Options;
            var entity = new Product { Id = 3 };

            // act
            Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                repo.Create(entity);
                repo.Save();
            });
            Product returnedEntity = Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                return repo.GetById(entity.Id);
            });

            //assert
            returnedEntity.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public void GetById_EntityWithIdDoesNotExist_NullIsReturned()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_FirstDotNetCoreApp")
                .Options;
            var entity = new Product { Id = 4 };

            // act
            Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                repo.Create(entity);
                repo.Save();
            });
            Product returnedEntity = Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                return repo.GetById(5);
            });

            //assert
            returnedEntity.Should().BeNull("Because there is no entity with given id");
        }

        [Fact]
        public void FindAll_ThreeEntitiesAlreadyExist_NumberOfEntitiesReturnedIsThree()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_FirstDotNetCoreApp")
                .Options;
            var entity1 = new Product { Id = 5 };
            var entity2 = new Product { Id = 6 };
            var entity3 = new Product { Id = 7 };

            // act
            Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                repo.Create(entity1);
                repo.Create(entity2);
                repo.Create(entity3);
                repo.Save();
            });
            int numberOfItems = Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                return repo.FindAll().Count();
            });

            //assert
            numberOfItems.Should().Be(3);
        }

        [Fact]
        public void FindByCondition_EntitiesWithSameNameExist_OnlyEntityWithCategoryMatchingIsReturned()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_FirstDotNetCoreApp")
                .Options;
            var entity1 = new Product { Id = 8, Name = "Product1", Category = "Category1" };
            var entity2 = new Product { Id = 9, Name = "Product1", Category = "Category2" };

            // act
            Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                repo.Create(entity1);
                repo.Create(entity2);
                repo.Save();
            });
            Product itemMatchingCondition = Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                return repo.FindByCondition(e => e.Name == "Product1" && e.Category == "Category1").FirstOrDefault();
            });

            //assert
            itemMatchingCondition.Should().BeEquivalentTo(entity1);
        }
    }
}
