using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        public IEnumerable<Document> Get()
        {
            var documents = new List<Document>
            {
                new Document
                {
                    Id = 1,
                    Name = "file1",
                    Data = new byte[10]
                },
                new Document
                {
                    Id = 2,
                    Name = "file2",
                    Data = new byte[10]
                }
            };

            return documents;
        }
    }
}
