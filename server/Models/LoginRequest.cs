using System.ComponentModel.DataAnnotations;

namespace FlavorFinder.Models
{
    public class LoginRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }
    }
}