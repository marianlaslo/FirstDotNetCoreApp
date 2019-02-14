using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.BusinessLayer.Services.Abstractions;
using FirstDotNetCoreApp.Mappers;
using FirstDotNetCoreApp.Models;
using FirstDotNetCoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFormFileService _formFileService;
        private readonly IEntityMapper<FormFileViewModel, FormFile> _formFileMapper;

        public FilesController(IHostingEnvironment hostingEnvironment, 
            IFormFileService formFileService,
            IEntityMapper<FormFileViewModel, FormFile> formFileMapper)
        {
            _hostingEnvironment = hostingEnvironment;
            _formFileService = formFileService;
            _formFileMapper = formFileMapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FormFile>> Get()
        {
            var formFiles = _formFileService.GetFormFiles().Select(_formFileMapper.Convert);

            return Ok(formFiles);
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
