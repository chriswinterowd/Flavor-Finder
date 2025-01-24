using FlavorFinder.Data;
using FlavorFinder.Models;
using Microsoft.EntityFrameworkCore;

namespace FlavorFinder.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext _context;

        public RecipeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Recipe?> GetByIdAsync(int id)
        {
            return await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Recipe>> GetRecipesAsync(string meal, string cuisine)
        {
            return await _context.Recipes
                .Where(r => r.DishTypes.Contains(meal) && r.Cuisines.Contains(cuisine))
                .ToListAsync();
        }
    }
}