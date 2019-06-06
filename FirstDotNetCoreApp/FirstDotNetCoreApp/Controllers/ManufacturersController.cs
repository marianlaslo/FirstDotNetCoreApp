using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.BusinessLayer.Services.Abstractions;
using FirstDotNetCoreApp.Mappers;
using FirstDotNetCoreApp.Models;
using FirstDotNetCoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IEntityMapper<ManufacturerViewModel, Manufacturer> _manufacturerMapper;

        public ManufacturersController(IManufacturerService manufacturerService,
            IEntityMapper<ManufacturerViewModel, Manufacturer> manufacturerMapper)
        {
            _manufacturerService = manufacturerService;
            _manufacturerMapper = manufacturerMapper;
        }

        // GET api/manufacturers
        [HttpGet]
        public ActionResult<IEnumerable<ManufacturerViewModel>> Get()
        {
            var manufacturers = _manufacturerService.GetManufacturers().Select(_manufacturerMapper.Convert);

            return Ok(manufacturers);
        }
    }
}
