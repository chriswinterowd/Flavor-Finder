namespace FlavorFinder.Services
{
    public interface IAuthService
    {
        Task<bool> Register(string email, string password);
        Task<bool> Login(string email, string password, bool rememberMe);
        Task Logout();
    }
}