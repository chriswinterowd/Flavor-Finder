using Microsoft.AspNetCore.Mvc;
using FlavorFinder.Services;
using FlavorFinder.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FlavorFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly SpoonacularService _spoonacularService;
        private readonly IRecipeService _recipeService;

        public RecipeController(SpoonacularService spoonacularService, IRecipeService recipeService)
        {
            _spoonacularService = spoonacularService;
            _recipeService = recipeService;
        }

        /*[Authorize]
        [HttpPost("favorite")]
        public async Task<IActionResult> FavoriteRecipe(int recipeId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID was not found");
            }

            var result = await _recipeService.FavoriteRecipe(userId, recipeId);

            if (result)
            {
                return Ok();
            }

            return BadRequest("Recipe was not added to favorites.")

        }
        */


        [HttpGet("random")]
        public async Task<ActionResult<Recipe>> GetRandomRecipes([FromQuery] string meal = "", string cuisine = "")
        {
            try
            {
                var recipe = await _spoonacularService.GetRandomRecipe(meal, cuisine);

                if (recipe == null)
                {
                    return NotFound("No recipes found");
                }

                await _recipeService.SaveRecipeAsync(recipe);
                Console.WriteLine("sending " + recipe);
                return Ok(recipe);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"API Error: {ex.Message}");

                var fallbackRecipe = await _recipeService.GetRandomRecipeAsync(meal, cuisine);

                if (fallbackRecipe == null)
                {
                    return NotFound("No recipes found in the database");
                }

                return Ok(fallbackRecipe);
            }
        }
    }
}