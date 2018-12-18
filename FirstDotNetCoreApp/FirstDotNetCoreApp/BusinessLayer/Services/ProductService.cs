using FirstDotNetCoreApp.BusinessLayer.Services.Abstractions;
using FirstDotNetCoreApp.DataAccess.Repositories.Abstractions;
using FirstDotNetCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var prod = _productRepository.Update(product);
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
