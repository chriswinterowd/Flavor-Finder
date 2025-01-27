using Microsoft.AspNetCore.Mvc;
using FlavorFinder.Services;
using FlavorFinder.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;

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

        [Authorize]
        [HttpGet("favorite/{recipeId}")]
        public async Task<ActionResult<Boolean>> IsFavorited(int recipeId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID was not found");
            }

            var isFavorited = await _recipeService.IsRecipeFavoritedAsync(userId, recipeId);

            return Ok(new { isFavorited });
        }
        [Authorize]
        [HttpPost("favorite/{recipeId}")]
        public async Task<IActionResult> FavoriteRecipe(int recipeId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID was not found");
            }

            await _recipeService.FavoriteRecipeAsync(userId, recipeId);

            return Ok("Recipe was added to favorites.");

        }

        [Authorize]
        [HttpDelete("favorite/{recipeId}")]
        public async Task<IActionResult> UnfavoriteRecipe(int recipeId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID was not found");
            }

            await _recipeService.UnfavoriteRecipeAsync(userId, recipeId);

            return Ok("Recipe was removed from favorites");
        }

        [Authorize]
        [HttpGet("favorites")]
        public async Task<ActionResult<List<Favorite>>> GetUserFavorites()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID was not found");
            }
            var favorites = await _recipeService.GetUserFavoritesAsync(userId);

            return Ok(favorites);

        }

        [HttpGet("{recipeId}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int recipeId)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(recipeId);
            return Ok(recipe);
        }
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