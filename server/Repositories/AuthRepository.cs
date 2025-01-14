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

        public async Task<SignInResult> LoginUserAsync(string identifier, string password, bool rememberMe)
        {
            //Check if input is email
            var user = await _userManager.FindByEmailAsync(identifier);

            //If not email then check if username exists
            if (string.IsNullOrEmpty(user?.UserName))
            {
                user = await _userManager.FindByNameAsync(identifier);
            }

            //If username not found then sign in failed
            if (string.IsNullOrEmpty(user?.UserName))
            {
                return SignInResult.Failed;
            }
            return await _signInManager.PasswordSignInAsync(user.UserName, password, isPersistent: rememberMe, lockoutOnFailure: false);
        }

        public async Task LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}