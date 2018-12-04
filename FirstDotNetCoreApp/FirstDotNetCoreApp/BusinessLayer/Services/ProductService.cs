﻿using FirstDotNetCoreApp.BusinessLayer.Services.Abstractions;
using FirstDotNetCoreApp.DataAccess.Repositories.Abstractions;
using FirstDotNetCoreApp.Models;
using System;
using System.Collections.Generic;

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
            // var products = _productRepository.FindByCondition(p => p.Id == id);
            // return products.
            throw new NotImplementedException();
        }

        public Product CreateProduct(Product product)
        {
            return _productRepository.Create(product);
        }

        public Product UpdateProduct(Product product)
        {
            return _productRepository.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            _productRepository.Delete(product);
        }

        
    }
}
