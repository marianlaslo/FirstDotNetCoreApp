using FirstDotNetCoreApp.Models;

namespace FirstDotNetCoreApp.DataAccess.Repositories.Abstractions
{
    public class ManufacturerRepository : RepositoryBase<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(MyDbContext myDbContext) 
            :base(myDbContext)
        {
        }
    }
}
