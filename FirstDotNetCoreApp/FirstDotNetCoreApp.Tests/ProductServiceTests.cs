
using FirstDotNetCoreApp.BusinessLayer.Services;
using FirstDotNetCoreApp.DataAccess;
using FirstDotNetCoreApp.DataAccess.Repositories;
using FirstDotNetCoreApp.Extensions;
using FirstDotNetCoreApp.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FirstDotNetCoreApp.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void Create_NewProduct_NewProductIsCreated()
        {
            // arrange
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory_FirstDotNetCoreApp")
                .Options;
            var product = new Product {Id = 1, Name = "NewProduct"};

            // act
            Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                var service = new ProductService(repo);
                service.CreateProduct(product);
            });
            var newProduct = Disposable.Using(() => new MyDbContext(options), context =>
            {
                var repo = new ProductRepository(context);
                var service = new ProductService(repo);
                return service.GetProduct(product.Id);
            });

            // assert
            newProduct.Should().BeEquivalentTo(product);
        }
    }
}
