using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FlavorFinder.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(string username, string email, string password)
        {
            var user = new IdentityUser { UserName = username, Email = email };
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> LoginUserAsync(string username, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(username, password, isPersistent: rememberMe, lockoutOnFailure: false);
        }

        public async Task LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}