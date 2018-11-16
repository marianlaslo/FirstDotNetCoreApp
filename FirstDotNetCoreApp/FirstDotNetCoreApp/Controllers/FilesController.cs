using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<FormFile>> Get()
        {
            var FormFiles = new List<FormFile>
            {
                new FormFile
                {
                    Id = 1,
                    Name = "formFile1",
                    Data = new byte[10]
                },
                new FormFile
                {
                    Id = 2,
                    Name = "formFile2",
                    Data = new byte[10]
                }
            };

            return FormFiles;
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var filePath = Path.GetTempFileName();

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            return Ok(new { count = files.Count, size, filePath });
        }
    }
}
