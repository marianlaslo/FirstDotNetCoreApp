using System.Collections.Generic;
using FirstDotNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET api/products
        [HttpGet]
        public IEnumerable<Product> Get()
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
        public Product Get(int id)
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
        public void Post([FromBody] Product product)
        {
            
        }

        // PUT api/products/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            
        }

        // DELETE api/products/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        { 
            
        }
    }
}
