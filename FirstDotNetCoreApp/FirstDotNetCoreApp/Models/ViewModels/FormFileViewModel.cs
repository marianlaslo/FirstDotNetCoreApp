using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDotNetCoreApp.Models.ViewModels
{
    public class FormFileViewModel
    {
        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }

        public long Length { get; set; }
    }
}
