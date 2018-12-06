using System.Collections.Generic;
using System.Linq;
using FirstDotNetCoreApp.BusinessLayer.Services.Abstractions;
using FirstDotNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _productService.GetProducts();

            return products.ToList();
        }

        // GET api/products/id
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productService.GetProduct(id);

            return product;
        }

        // POST api/products
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            var newProduct = _productService.CreateProduct(product);

            return Ok(newProduct);
        }

        // PUT api/products/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            var updatedProduct = _productService.UpdateProduct(product);

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
