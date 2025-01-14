using Microsoft.AspNetCore.Identity;

namespace FlavorFinder.Services
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(string username, string email, string password);
        Task<SignInResult> Login(string identifier, string password, bool rememberMe);
        Task Logout();
    }
}