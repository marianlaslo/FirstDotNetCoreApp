using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.Models.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstDotNetCoreApp.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }

        public HashSet<ProductIngredient> ProductIngredients { get; set; }
    }
}
