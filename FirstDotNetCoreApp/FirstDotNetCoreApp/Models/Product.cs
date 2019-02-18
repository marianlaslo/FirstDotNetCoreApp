using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using FirstDotNetCoreApp.Models.Abstractions;

namespace FirstDotNetCoreApp.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public int ManufacturerId { get; set; }

        [ForeignKey("ManufacturerId")]
        public Manufacturer Manufacturer { get; set; }

        public HashSet<ProductIngredient> ProductIngredients { get; set; }
    }
}
