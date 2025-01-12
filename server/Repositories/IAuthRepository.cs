using Microsoft.AspNetCore.Identity;

namespace FlavorFinder.Repositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUserAsync(string username, string email, string password);
        Task<SignInResult> LoginUserAsync(string username, string password, bool isPersistent);
        Task LogoutUserAsync();
    }
}
