using FlavorFinder.Services;
using FlavorFinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlavorFinder.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var success = await _authService.Register(request.Username, request.Email, request.Password);
            if (!success)
            {
                return BadRequest("Registration failed.");
            }
            return Ok("Registration Successful.");
        }

        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var success = await _authService.Login(request.Username, request.Password, request.RememberMe);
            if (!success)
            {
                return Unauthorized("Invalid login credentials.");
            }
            return Ok("Login successful.");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return Ok("Logout succesful.");
        }
    }
}