using FlavorFinder.Models;

namespace FlavorFinder.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe?> GetByIdAsync(int id);
        Task AddAsync(Recipe recipe);
        Task<Recipe?> GetRandomByTagsAsync(string meal, string cuisine);
    }
}
