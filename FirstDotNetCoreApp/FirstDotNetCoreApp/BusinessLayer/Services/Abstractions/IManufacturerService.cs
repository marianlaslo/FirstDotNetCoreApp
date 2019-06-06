using System.Collections.Generic;
using FirstDotNetCoreApp.Models;

namespace FirstDotNetCoreApp.BusinessLayer.Services.Abstractions
{
    public interface IManufacturerService
    {
        IEnumerable<Manufacturer> GetManufacturers();

        Manufacturer GetManufacturer(int id);

        Manufacturer CreateManufacturer(Manufacturer manufacturer);

        Manufacturer UpdateManufacturer(Manufacturer manufacturer);

        void DeleteManufacturer(int id);
    }
}
