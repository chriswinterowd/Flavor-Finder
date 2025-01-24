using FlavorFinder.Models;
using FlavorFinder.Repositories;
namespace FlavorFinder.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task SaveRecipeAsync(Recipe recipeToSave)
        {

            try
            {
                await _recipeRepository.AddAsync(recipeToSave);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving recipe ID {recipeToSave.Id}: {ex.Message}");
            }

        }

        public async Task<Recipe?> GetRandomRecipeAsync(string meal, string cuisine)
        {
            var recipes = await _recipeRepository.GetRecipesAsync(meal, cuisine);

            if (recipes.Count == 0)
            {
                return null;
            }

            var randomIndex = new Random().Next(recipes.Count);
            return recipes[randomIndex];
        }
    }
}