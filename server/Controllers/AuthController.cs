using FlavorFinder.Services;
using FlavorFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
            var result = await _authService.Register(request.UserName, request.Email, request.Password);
            if (result.Succeeded)
            {
                return Ok("Registration Successful.");
            }

            var errors = result.Errors.Select(e => e.Description).ToList();
            return BadRequest(new { Errors = errors });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.Login(request.Identifier, request.Password, request.RememberMe);
            if (result.Succeeded)
            {
                return Ok("Login successful.");
            }

            var errors = new List<string>();

            if (result.IsLockedOut)
            {
                errors.Add("Your account is locked. Please try again later.");
            }
            if (result.IsNotAllowed)
            {
                errors.Add("You are not allowed to log in at this time.");
            }
            if (!result.Succeeded)
            {
                errors.Add("Invalid username or password.");
            }

            return BadRequest(new { Errors = errors });
        }

        [HttpGet("check")]
        public IActionResult CheckAuthentication()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return Ok(new { IsAuthenticated = true });
            }
            else
            {
                return Ok(new { IsAuthenticated = false });
            }
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return Ok();
        }
    }
}