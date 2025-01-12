namespace FlavorFinder.Services
{
    public interface IAuthService
    {
        Task<bool> Register(string username, string email, string password);
        Task<bool> Login(string username, string password, bool rememberMe);
        Task Logout();
    }
}