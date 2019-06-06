using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FirstDotNetCoreApp.BusinessLayer.Services.Abstractions;
using FirstDotNetCoreApp.DataAccess.Repositories.Abstractions;
using FirstDotNetCoreApp.Models;

namespace FirstDotNetCoreApp.BusinessLayer.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerService(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            return _manufacturerRepository.FindAll();
        }

        public IEnumerable<Manufacturer> GetManufacturersByCondition(Expression<Func<Manufacturer, bool>> condition)
        {
            var manufacturers = _manufacturerRepository.FindByCondition(condition);
            return manufacturers;
        }

        public Manufacturer GetManufacturer(int id)
        {
            var manufacturer = _manufacturerRepository.GetById(id);
            return manufacturer;
        }

        public Manufacturer CreateManufacturer(Manufacturer manufacturer)
        {
            var newManufacturer = _manufacturerRepository.Create(manufacturer);
            _manufacturerRepository.Save();

            return newManufacturer;
        }

        public Manufacturer UpdateManufacturer(Manufacturer manufacturer)
        {
            var updatedManufacturer = _manufacturerRepository.Update(manufacturer, nameof(Manufacturer.Name), nameof(Manufacturer.Address));
            _manufacturerRepository.Save();

            return updatedManufacturer;
        }

        public void DeleteManufacturer(int id)
        {
            _manufacturerRepository.Delete(id);
            _manufacturerRepository.Save();
        }
    }
}
