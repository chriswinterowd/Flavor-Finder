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

        public RecipeController(SpoonacularService spoonacularService)
        {
            _spoonacularService = spoonacularService;
        }

        [HttpGet("random")]
        public async Task<ActionResult<List<Recipe>>> GetRandomRecipes([FromQuery] int number = 1, string meal = "", string cuisine = "")
        {
            try
            {
                var recipes = await _spoonacularService.GetRandomRecipes(number, meal, cuisine);

                if (recipes == null || recipes.Count == 0)
                {
                    return NotFound("No recipes  found");
                }

                return Ok(recipes);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error fetching recipes: {ex.Message}");
            }
        }
    }
}