using FlavorFinder.Models;
using FlavorFinder.Repositories;
using Microsoft.Extensions.ObjectPool;
namespace FlavorFinder.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IFavoriteRepository _favoriteRepository;

        public RecipeService(IRecipeRepository recipeRepository, IFavoriteRepository favoriteRepository)
        {
            _recipeRepository = recipeRepository;
            _favoriteRepository = favoriteRepository;
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

        public async Task<Recipe?> GetRecipeByIdAsync(int recipeId)
        {
            return await _recipeRepository.GetByIdAsync(recipeId);
        }
        public async Task FavoriteRecipeAsync(string userId, int recipeId)
        {
            var favorite = new Favorite { UserId = userId, RecipeId = recipeId };
            await _favoriteRepository.AddAsync(favorite);

        }

        public async Task UnfavoriteRecipeAsync(string userId, int recipeId)
        {
            var favorite = new Favorite { UserId = userId, RecipeId = recipeId };
            await _favoriteRepository.RemoveAsync(favorite);
        }

        public async Task<List<Recipe>> GetUserFavoritesAsync(string userId)
        {
            var favorites = await _favoriteRepository.GetFavoritesByUserIdAsync(userId);
            var recipeIds = favorites.Select(f => f.RecipeId).ToList();

            var recipes = await _recipeRepository.GetByIdsAsync(recipeIds);

            return recipes;
        }

        public async Task<bool> IsRecipeFavoritedAsync(string userId, int recipeId)
        {
            var favorite = new Favorite { UserId = userId, RecipeId = recipeId };
            return await _favoriteRepository.IsFavoriteAsync(favorite);
        }

    }
}