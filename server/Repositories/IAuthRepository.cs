using Microsoft.AspNetCore.Identity;

namespace FlavorFinder.Repositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUserAsync(string email, string password);
        Task<SignInResult> LoginUserAsync(string email, string password, bool isPersistent);
        Task LogoutUserAsync();
    }
}
