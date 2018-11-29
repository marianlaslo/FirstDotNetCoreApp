using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.DataAccess.Repositories.Abstractions;
using FirstDotNetCoreApp.Models;

namespace FirstDotNetCoreApp.DataAccess.Repositories
{
    public class FormFileRepository: RepositoryBase<FormFile>, IFormFileRepository
    {
        public FormFileRepository(MyDbContext myDbContext) 
            :base(myDbContext)
        {
        }
    }
}
