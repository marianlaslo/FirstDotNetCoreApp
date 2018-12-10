using FirstDotNetCoreApp.Models;
using System.Collections.Generic;

namespace FirstDotNetCoreApp.BusinessLayer.Services.Abstractions
{
    public interface IFormFileService
    {
        IEnumerable<FormFile> GetFormFiles();

        FormFile GetFormFile(int id);

        FormFile CreateFormFile(FormFile formFile);

        FormFile UpdateFormFile(FormFile formFile);

        void DeleteFormFile(int id);
    }
}
