using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.Models;
using FirstDotNetCoreApp.Models.ViewModels;

namespace FirstDotNetCoreApp.Mappers
{
    public class ProductMapper 
    {
        public ProductViewModel Convert(Product product)
        {
            var productVm = new ProductViewModel();

            return productVm;
        }
    }
}
