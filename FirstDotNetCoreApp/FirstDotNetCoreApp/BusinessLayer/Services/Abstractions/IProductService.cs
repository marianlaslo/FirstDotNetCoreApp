using FirstDotNetCoreApp.Models;
using System.Collections.Generic;

namespace FirstDotNetCoreApp.BusinessLayer.Services.Abstractions
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        Product GetProduct(int id);

        Product CreateProduct(Product product);

        Product UpdateProduct(Product product);

        void DeleteProduct(int id);
    }
}
