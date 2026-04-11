using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sa3dny.Data.Models
{
    public class Customer : ApplicationUser
    {
        [Key]
        public int Id_Customer { get; set; }

        [ForeignKey("GovernorateId")]
        public Governorate Governorate { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public ICollection<Requests> requests { get; set; }
        public ICollection<Review> reviews { get; set; }
    }
}