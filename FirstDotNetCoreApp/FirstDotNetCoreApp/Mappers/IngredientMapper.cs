using FirstDotNetCoreApp.Models;
using FirstDotNetCoreApp.Models.ViewModels;

namespace FirstDotNetCoreApp.Mappers
{
    public class IngredientMapper : IEntityMapper<IngredientViewModel, Ingredient>
    {
        public IngredientViewModel Convert(Ingredient model)
        {
            var ingredientVm = new IngredientViewModel
            {
                Name = model.Name
            };

            return ingredientVm;
        }
    }
}
