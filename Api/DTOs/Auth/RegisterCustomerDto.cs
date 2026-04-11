using System.ComponentModel.DataAnnotations;

namespace Sa3dny.Api.DTOs.Auth
{
    public class RegisterCustomerDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        
        [Required]
        public string LocationName { get; set; }
    }
}