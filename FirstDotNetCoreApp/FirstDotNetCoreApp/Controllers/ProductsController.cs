using System.Collections.Generic;
using FirstDotNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "product1",
                    Category = "category1"
                },
                new Product
                {
                    Id = 2,
                    Name = "product2",
                    Category = "category2"
                }
            };


            return products;
        }

        // GET api/products/id
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return new Product
            {
                Id = 99,
                Name = "product",
                Category = "category"
            };
        }

        // POST api/products
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            return Ok();
        }

        // PUT api/products/id
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            return Ok();
        }

        // DELETE api/products/id
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
