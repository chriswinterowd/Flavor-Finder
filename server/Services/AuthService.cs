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

        public async Task<bool> Register(string username, string email, string password)
        {
            var result = await _authRepository.RegisterUserAsync(username, email, password);
            return result.Succeeded;
        }

        public async Task<bool> Login(string username, string password, bool rememberMe)
        {
            var result = await _authRepository.LoginUserAsync(username, password, rememberMe);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _authRepository.LogoutUserAsync();
        }
    }
}