using FlavorFinder.Models;

namespace FlavorFinder.Services
{
    public interface IRecipeService
    {
        Task SaveRecipeAsync(Recipe recipeToSave);
        Task<Recipe?> GetRandomRecipeAsync(string meal, string cuisine);
    }
}