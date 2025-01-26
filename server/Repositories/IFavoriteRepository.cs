using FlavorFinder.Models;

namespace FlavorFinder.Repositories
{
    public interface IFavoriteRepository
    {
        Task AddAsync(Favorite favorite);
        Task RemoveAsync(Favorite favorite);
        Task<List<Favorite>> GetFavoritesByUserIdAsync(string userId);
    }
}