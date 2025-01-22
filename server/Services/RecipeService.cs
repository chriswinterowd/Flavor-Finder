using FlavorFinder.Models;
using FlavorFinder.Repositories;
namespace FlavorFinder.Services
{
    public class RecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task SaveRecipesAsync(List<Recipe> Recipes)
        {
            foreach (var recipe in Recipes)
            {
                try
                {
                    await _recipeRepository.AddAsync(recipe);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving recipe ID {recipe.Id}: {ex.Message}");
                }
            }
        }

        public async Task<List<Recipe>> GetRecipeByTagsAsync(string meal, string cuisine)
        {
            return await _recipeRepository.GetRandomByTagsAsync(meal, cuisine);
        }
    }
}