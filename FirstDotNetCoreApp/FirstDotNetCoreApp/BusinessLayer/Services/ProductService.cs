using FirstDotNetCoreApp.BusinessLayer.Services.Abstractions;
using FirstDotNetCoreApp.DataAccess.Repositories.Abstractions;
using FirstDotNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FirstDotNetCoreApp.BusinessLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.FindAll();
        }

        public IEnumerable<Product> GetProductsByCondition(Expression<Func<Product, bool>> condition)
        {
            var productsByCondition = _productRepository.FindByCondition(condition);
            return productsByCondition;
        }

        public Product GetProduct(int id)
        {
            var product = _productRepository.GetById(id);
            return product;
        }

        public Product CreateProduct(Product product)
        {
            var prod = _productRepository.Create(product);
            _productRepository.Save();

            return prod;
        }

        public Product UpdateProduct(Product product)
        {
            var prod = _productRepository.Update(product, nameof(Product.Name), nameof(Product.Category));
            _productRepository.Save();

            return prod;
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
            _productRepository.Save();
        }
    }
}
