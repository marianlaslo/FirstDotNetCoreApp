using FirstDotNetCoreApp.Models;
using System.Collections.Generic;

namespace FirstDotNetCoreApp.BusinessLayer.Services.Abstractions
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetIngredients();

        Ingredient GetIngredient(int id);

        Ingredient CreateIngredient(Ingredient ingredient);

        Ingredient UpdateIngredient(Ingredient ingredient);

        void DeleteIngredient(int id);
    }
}
