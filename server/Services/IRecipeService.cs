using FlavorFinder.Models;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace FlavorFinder.Services
{
    public interface IRecipeService
    {
        Task SaveRecipeAsync(Recipe recipeToSave);

        Task<Recipe?> GetRandomRecipeAsync(string meal, string cuisine);

        Task FavoriteRecipeAsync(string userId, int recipeId);

        Task UnfavoriteRecipeAsync(string userId, int recipeId);

        Task<List<Favorite>> GetUserFavoritesAsync(string userId);

        Task<bool> IsRecipeFavoritedAsync(string userId, int recipeId);

        Task<Recipe?> GetRecipeByIdAsync(int recipeId);
    }
}