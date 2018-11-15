using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDotNetCoreApp.Models
{
    public class FormFile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }

        public long Length { get; set; }

        public Stream FileStream { get; set; }
    }
}
