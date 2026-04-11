using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sa3dny.Data.Models
{
    public class Provider : ApplicationUser
    {
        [Key]
        public int provider_id { get; set; }

        [Required]
        [DisplayName("National ID")]
        [StringLength(14)]
        public string national_id_Provider { get; set; }

        [DisplayName("Rate")]
        public double? rate_Provider { get; set; }

        [Required]
        [DisplayName("Service Category")]
        public int ServiceCategoryId { get; set; }

        [ForeignKey("ServiceCategoryId")]
        public ServiceCategory ServiceCategory { get; set; }
      
        [Required]
        [DisplayName("Service")]
        public int ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public Service Service { get; set; }

        [ForeignKey("GovernorateId")]
        public Governorate Governorate { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

       
        [Required]
        [DisplayName("National ID Image")]
        public string NationalIdImagePath { get; set; }

        [Required]
        [DisplayName("Professional License")]
        public string ProfessionalLicensePath { get; set; }

        public ICollection<Review> reviews { get; set; }
        public ICollection<Provider_Service> provider_Services { get; set; }
        public ICollection<Requests> requests { get; set; }
    }
}