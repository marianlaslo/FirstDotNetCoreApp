using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.Models;
using FirstDotNetCoreApp.Models.ViewModels;

namespace FirstDotNetCoreApp.Mappers
{
    public class FormFileMapper : IEntityMapper<FormFileViewModel, FormFile>
    {
        public FormFileViewModel Convert(FormFile model)
        {
            var formFileVm = new FormFileViewModel
            {
                Name = model.Name,
                ContentType = model.ContentType,
                Data = model.Data,
                Length = model.Length
            };

            return formFileVm;
        }
    }
}
