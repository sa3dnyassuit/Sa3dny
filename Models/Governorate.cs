using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sa3dny.Data.Models
{
    public class Governorate
    {
        [Key]
        public int Id_Governorate { get; set; }

        [Required]
        public string Name_Governorate { get; set; }

        public ICollection<Location> Locations { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Provider> Providers { get; set; }
    }
}