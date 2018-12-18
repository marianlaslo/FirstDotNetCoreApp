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
            var formFile = _formFileRepository.GetById(id);
            return formFile;
        }

        public FormFile CreateFormFile(FormFile formFile)
        {
            var file = _formFileRepository.Create(formFile);
            _formFileRepository.Save();

            return file;
        }

        public FormFile UpdateFormFile(FormFile formFile)
        {
            var file = _formFileRepository.Update(formFile);
            _formFileRepository.Save();

            return file;
        }

        public void DeleteFormFile(int id)
        {
            _formFileRepository.Delete(id);
        }
    }
}
