using FirstDotNetCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDotNetCoreApp.DataAccess
{
    public class MyDbContext: DbContext
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
    }
}
