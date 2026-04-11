using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sa3dny.Data.Models
{
    public class Location
    {
        [Key]
        public int Id_Location { get; set; }

        [Required]
        [DisplayName("Location Name")]
        public string Name_Location { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}