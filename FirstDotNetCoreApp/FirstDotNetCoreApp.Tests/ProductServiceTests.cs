
using System;
using FirstDotNetCoreApp.BusinessLayer.Services;
using FirstDotNetCoreApp.DataAccess;
using FirstDotNetCoreApp.DataAccess.Repositories;
using FirstDotNetCoreApp.DataAccess.Repositories.Abstractions;
using FirstDotNetCoreApp.Extensions;
using FirstDotNetCoreApp.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace FirstDotNetCoreApp.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void Create_NewProduct_NewProductIsCreated()
        {
            // arrange 
            var repo = NSubstitute.Substitute.For<IProductRepository>();
            var service = new ProductService(repo);
            var product = new Product {Id = 1, Name = "NewProduct"};
            repo.Create(product).Returns(product);

            // act
            var createdProduct = service.CreateProduct(product);

            // assert
            createdProduct.Should().BeEquivalentTo(product);
        }

        [Fact]
        public void Get()
        {
            // arrange

            // act

            // assert
        }
    }
}
