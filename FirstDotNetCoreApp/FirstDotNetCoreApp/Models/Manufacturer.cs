using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.Models.Abstractions;

namespace FirstDotNetCoreApp.Models
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        
        public string Address { get; set; }

        public HashSet<Product> Products { get; set; }
    }
}
