using System.Collections.Generic;
using System.Linq;
using FirstDotNetCoreApp.ActionFilters;
using FirstDotNetCoreApp.BusinessLayer.Services.Abstractions;
using FirstDotNetCoreApp.Mappers;
using FirstDotNetCoreApp.Models;
using FirstDotNetCoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IEntityMapper<ProductViewModel, Product> _productMapper;

        public ProductsController(IProductService productService, 
            IEntityMapper<ProductViewModel, Product> productMapper)
        {
            _productService = productService;
            _productMapper = productMapper;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<ProductViewModel>> Get()
        {
            var products = _productService.GetProducts().Select(_productMapper.Convert);

            return Ok(products);
        }

        // GET api/products/id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var product = _productMapper.Convert(_productService.GetProduct(id));

            return Ok(product);
        }

        // POST api/products
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public ActionResult Post([FromBody] Product product)
        {
            var newProduct = _productMapper.Convert(_productService.CreateProduct(product));

            return Ok(newProduct);
        }

        // PUT api/products/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            product.Id = id;
            var updatedProduct = _productMapper.Convert(_productService.UpdateProduct(product));

            return Ok(updatedProduct);
        }

        // DELETE api/products/id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);

            return Ok();
        }
    }
}
