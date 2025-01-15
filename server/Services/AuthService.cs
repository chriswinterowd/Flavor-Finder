using FlavorFinder.Repositories;
using Microsoft.AspNetCore.Identity;

namespace FlavorFinder.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<IdentityResult> Register(string username, string email, string password)
        {
            var result = await _authRepository.RegisterUserAsync(username, email, password);
            return result;
        }

        public async Task<SignInResult> Login(string identifier, string password, bool rememberMe)
        {
            var result = await _authRepository.LoginUserAsync(identifier, password, rememberMe);
            return result;
        }

        public async Task Logout()
        {
            await _authRepository.LogoutUserAsync();
        }
    }
}