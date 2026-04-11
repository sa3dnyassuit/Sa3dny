using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sa3dny.Data.Models
{
    public class ServiceCategory
    {
        [Key]
        public int Id_Category { get; set; }

        [Required]
        public string Name_Category { get; set; }

        public ICollection<Service> Services { get; set; }
        public ICollection<Provider> Providers { get; set; }
    }
}