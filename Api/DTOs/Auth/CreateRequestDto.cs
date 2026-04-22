using System.ComponentModel.DataAnnotations;

namespace Sa3dny.Api.DTOs.Requests
{
    public class CreateRequestDto
    {
        [Required]
        public int Customer_Id { get; set; }

        [Required]
        public int Service_Id { get; set; }

        [Required]
        public string Description_Req { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}