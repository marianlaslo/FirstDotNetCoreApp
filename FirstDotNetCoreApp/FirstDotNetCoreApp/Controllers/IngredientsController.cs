using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstDotNetCoreApp.ActionFilters;
using FirstDotNetCoreApp.BusinessLayer.Services.Abstractions;
using FirstDotNetCoreApp.Mappers;
using FirstDotNetCoreApp.Models;
using FirstDotNetCoreApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstDotNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly IEntityMapper<IngredientViewModel, Ingredient> _ingredientMapper;

        public IngredientsController(IIngredientService ingredientService,
            IEntityMapper<IngredientViewModel, Ingredient> ingredientMapper)
        {
            _ingredientService = ingredientService;
            _ingredientMapper = ingredientMapper;
        }

        // GET api/ingredients
        [HttpGet]
        public ActionResult<IEnumerable<IngredientViewModel>> Get()
        {
            var ingredients = _ingredientService.GetIngredients().Select(_ingredientMapper.Convert);

            return Ok(ingredients);
        }

        // POST api/ingredients

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public ActionResult Post([FromBody] Ingredient ingredient)
        {
            var newIngredient = _ingredientMapper.Convert(_ingredientService.CreateIngredient(ingredient));

            return Ok(newIngredient);
        }
    }
}
