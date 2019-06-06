using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FirstDotNetCoreApp.BusinessLayer.Services.Abstractions;
using FirstDotNetCoreApp.DataAccess.Repositories.Abstractions;
using FirstDotNetCoreApp.Models;

namespace FirstDotNetCoreApp.BusinessLayer.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            return _ingredientRepository.FindAll();
        }

        public IEnumerable<Ingredient> GetIngredientsByCondition(Expression<Func<Ingredient, bool>> condition)
        {
            var ingredients = _ingredientRepository.FindByCondition(condition);

            return ingredients;
        }

        public Ingredient GetIngredient(int id)
        {
            var ingredient = _ingredientRepository.GetById(id);

            return ingredient;
        }

        public Ingredient CreateIngredient(Ingredient ingredient)
        {
            var newIngredient = _ingredientRepository.Create(ingredient);
            _ingredientRepository.Save();

            return newIngredient;
        }

        public Ingredient UpdateIngredient(Ingredient ingredient)
        {
            var updatedIngredient = _ingredientRepository.Update(ingredient, nameof(Ingredient.Name));
            _ingredientRepository.Save();

            return updatedIngredient;
        }

        public void DeleteIngredient(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
