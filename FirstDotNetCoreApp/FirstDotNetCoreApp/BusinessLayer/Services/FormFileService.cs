using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.BusinessLayer.Services.Abstractions;
using FirstDotNetCoreApp.DataAccess.Repositories.Abstractions;
using FirstDotNetCoreApp.Models;

namespace FirstDotNetCoreApp.BusinessLayer.Services
{
    public class FormFileService : IFormFileService
    {
        private readonly IFormFileRepository _formFileRepository;

        public FormFileService(IFormFileRepository formFileRepository)
        {
            _formFileRepository = formFileRepository;
        }

        public IEnumerable<FormFile> GetFormFiles()
        {
            return _formFileRepository.FindAll();
        }

        public FormFile GetFormFile(int id)
        {
            throw new NotImplementedException();
        }

        public FormFile CreateFormFile(FormFile formFile)
        {
            return _formFileRepository.Create(formFile);
        }

        public FormFile UpdateFormFile(FormFile formFile)
        {
            return _formFileRepository.Update(formFile);
        }

        public void DeleteFormFile(FormFile formFile)
        {
            _formFileRepository.Delete(formFile);
        }
    }
}
