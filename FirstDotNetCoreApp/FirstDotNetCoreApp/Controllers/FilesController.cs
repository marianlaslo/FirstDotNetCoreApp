using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;

        public FilesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FormFile>> Get()
        {
            var formFiles = new List<FormFile>
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

            return formFiles;
        }

        [HttpPost("UploadFile")]
        public ActionResult PostFile([FromForm] IFormFile uploadedFile)
        {
            string folderName = "Upload";
            string webRootPath = _hostingEnvironment.ContentRootPath;
            string newPath = Path.Combine(webRootPath, folderName);

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            if (uploadedFile.Length > 0)
            {
                string fullPath = Path.Combine(newPath, uploadedFile.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    uploadedFile.CopyTo(stream);
                }
            }

            return Ok();
        }

        //[HttpPost("UploadFiles")]
        //public async Task<IActionResult> Post([FromForm] List<IFormFile> files)
        //{
        //    long size = files.Sum(f => f.Length);

        //    var filePath = Path.GetTempFileName();

        //    foreach (var file in files)
        //    {
        //        if (file.Length > 0)
        //        {
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(stream);
        //            }
        //        }
        //    }

        //    return Ok(new { count = files.Count, size, filePath });
        //}
    }
}
