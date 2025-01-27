using FlavorFinder.Models;

namespace FlavorFinder.Repositories
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetByIdsAsync(List<int> recipeIds);
        Task<Recipe?> GetByIdAsync(int id);
        Task AddAsync(Recipe recipe);
        Task<List<Recipe>> GetRecipesAsync(string meal, string cuisine);
    }
}
