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
        public void Create_NewEntity_EntityIsCreated()
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
        public void Create_CreateEntityThatExists_ExceptionIsThrown()
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
                return repo.GetById(0);
            });

            //assert
            returnedEntity.Should().BeNull("Because there is no entity with given id");
        }

        [Fact]
        public void FindAll_ThreeEntitiesAlreadyExist_NumberOfEntitiesReturnedIsThree()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_FirstDotNetCoreApp_ForFindAll")
                .Options;
            var entity1 = new Product { Id = 1 };
            var entity2 = new Product { Id = 2 };
            var entity3 = new Product { Id = 3 };

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
            var entity1 = new Product { Id = 5, Name = "Product1", Category = "Category1" };
            var entity2 = new Product { Id = 6, Name = "Product1", Category = "Category2" };

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

        [Fact]
        public void Update_EntityExists_EntityFieldsAreUpdated()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_FirstDotNetCoreApp")
                .Options;
            var entity = new Product { Id = 7, Name = "ProductToUpdate", Category = "Category" };
            
            // act
            Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                repo.Create(entity);
                repo.Save();
            });
            Product updatedEntity = Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                entity.Name = "UpdatedName";
                entity.Category = "NotCategory";
                repo.Update(entity, nameof(Product.Name), nameof(Product.Category));
                repo.Save();
                return repo.GetById(entity.Id);
            });

            // assert
            updatedEntity.Should().BeEquivalentTo(entity);
        }

        [Fact]
        public void Update_EntityDoesNotExists_ExceptionIsThrown()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_FirstDotNetCoreApp")
                .Options;
            var entity = new Product { Id = 8, Name = "ProductToUpdate", Category = "Category" };

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
                var entity2 = new Product { Id = 9, Name = "UpdatedProduct" };
                repo.Update(entity2, nameof(Product.Name));
                repo.Save();
            });

            //assert
            action.Should().Throw<DbUpdateConcurrencyException>(); ;
        }
    }
}
