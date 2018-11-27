using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDotNetCoreApp.Models
{
    public class FormFile
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }

        public long Length { get; set; }

        [NotMapped]
        public Stream FileStream { get; set; }
    }
}
