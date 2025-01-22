using System.ComponentModel.DataAnnotations;

namespace FlavorFinder.Models.Requests
{
    public class LoginRequest
    {
        [Required]
        public required string Identifier { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public bool RememberMe { get; set; }
    }
}