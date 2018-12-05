using FirstDotNetCoreApp.Models.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace FirstDotNetCoreApp.Models
{
    public class FormFile : BaseEntity
    {
        public string Name { get; set; }

        public string ContentType { get; set; }

        public byte[] Data { get; set; }

        public long Length { get; set; }

        [NotMapped]
        public Stream FileStream { get; set; }
    }
}
