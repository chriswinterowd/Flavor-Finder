using Microsoft.AspNetCore.Mvc;
using FlavorFinder.Services;
using FlavorFinder.Models;

namespace FlavorFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly SpoonacularService _spoonacularService;
        private readonly RecipeService _recipeService;

        public RecipeController(SpoonacularService spoonacularService, RecipeService recipeService)
        {
            _spoonacularService = spoonacularService;
            _recipeService = recipeService;
        }

        [HttpGet("random")]
        public async Task<ActionResult<List<Recipe>>> GetRandomRecipes([FromQuery] int number = 1, string meal = "", string cuisine = "")
        {
            try
            {
                var recipes = await _spoonacularService.GetRandomRecipes(number, meal, cuisine);

                if (recipes == null || recipes.Count == 0)
                {
                    return NotFound("No recipes found");
                }

                await _recipeService.SaveRecipesAsync(recipes);
                return Ok(recipes);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"API Error: {ex.Message}");

                var fallbackRecipes = await _recipeService.GetRecipeByTagsAsync(meal, cuisine);

                if (fallbackRecipes == null || !fallbackRecipes.Any())
                {
                    return NotFound("No recipes found in the database");
                }

                return Ok(fallbackRecipes);
            }
        }
    }
}