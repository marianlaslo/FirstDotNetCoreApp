using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.Models;
using FirstDotNetCoreApp.Models.ViewModels;

namespace FirstDotNetCoreApp.Mappers
{
    public class ManufacturerMapper : IEntityMapper<ManufacturerViewModel, Manufacturer>
    {
        public ManufacturerViewModel Convert(Manufacturer model)
        {
            var manufacturerVm = new ManufacturerViewModel
            {
                Name = model.Name,
                Address = model.Address
            };

            return manufacturerVm;
        }
    }
}
