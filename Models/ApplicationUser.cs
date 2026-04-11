using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sa3dny.Data.Models
{
    public class ApplicationUser
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Phone")]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        [MinLength(6)]
        public string PasswordHash { get; set; }

        [Required]
        [DisplayName("Governorate")]
        public int GovernorateId { get; set; }

        [Required]
        [DisplayName("Location")]
        public int LocationId { get; set; }

        public DateTime? created_at { get; set; }
    }
}