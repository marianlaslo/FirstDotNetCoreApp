
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FirstDotNetCoreApp.BusinessLayer.Services;
using FirstDotNetCoreApp.DataAccess.Repositories.Abstractions;
using FirstDotNetCoreApp.Models;
using FluentAssertions;
using Microsoft.Azure.KeyVault.Models;
using NSubstitute;
using Xunit;

namespace FirstDotNetCoreApp.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void CreateProduct_NewProduct_NewProductIsCreated()
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
        public void GetProduct_ProductExistsAndIdIsKnown_ProductIsReturned()
        {
            // arrange
            var repo = NSubstitute.Substitute.For<IProductRepository>();
            var service = new ProductService(repo);
            var newProduct = new Product {Id = 1, Name = "NewProduct"};
            repo.GetById(newProduct.Id).Returns(newProduct);

            // act
            var product = service.GetProduct(newProduct.Id);

            // assert
            product.Should().BeEquivalentTo(newProduct);
        }

        [Fact]
        public void GetProducts_MultipleProductsExist_ProductsAreReturned()
        {
            // arrange
            var repo = NSubstitute.Substitute.For<IProductRepository>();
            var service = new ProductService(repo);
            var product1 = new Product {Id = 1, Name = "NewProduct1"};
            var product2 = new Product {Id = 2, Name = "NewProduct2"};
            var product3 = new Product {Id = 3, Name = "NewProduct3"};
            IEnumerable<Product> products = new List<Product> {product1, product2, product3};
            repo.FindAll().Returns(products.AsQueryable());

            // act
            var returnedProducts = service.GetProducts();

            // assert
            returnedProducts.Count().Should().Be(products.Count());
        }

        [Fact]
        public void GetByCondition_MultipleProductsDifferentCategories_ReturnByCertainCategory()
        {
            // arrange
            var repo = NSubstitute.Substitute.For<IProductRepository>();
            var service = new ProductService(repo);
            var product1 = new Product {Id = 1, Name = "NewProduct", Category = "Category1"};
            IEnumerable<Product> products = new List<Product> { product1 };
            Expression<Func<Product, bool>> expression = p => p.Name == product1.Name && p.Category == product1.Category;
            repo.FindByCondition(expression)
                .Returns(products.AsQueryable());

            // act
            var productsByCondition = service.GetProductsByCondition(expression);

            // assert
            productsByCondition.Should().BeEquivalentTo(product1);

        }
    }
}
