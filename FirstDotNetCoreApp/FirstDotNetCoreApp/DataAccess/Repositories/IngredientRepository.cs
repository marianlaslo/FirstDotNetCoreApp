using FirstDotNetCoreApp.Models;

namespace FirstDotNetCoreApp.DataAccess.Repositories.Abstractions
{
    public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(MyDbContext myDbContext) 
            :base(myDbContext)
        {
        }
    }
}
