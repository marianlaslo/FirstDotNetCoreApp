using FirstDotNetCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDotNetCoreApp.DataAccess
{
    public interface IDbContext
    {
        
    }

    public class MyDbContext : DbContext, IDbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {

        }

        public MyDbContext()
        {

        }

        public DbSet<FormFile> Files { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(new Product { Id = -1, Category = "Category1", Name = "Product1" });

            modelBuilder.Entity<ProductIngredient>()
                .HasKey(t => new { t.ProductId, t.IngredientId });
        }
    }
}
