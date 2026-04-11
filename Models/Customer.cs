using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sa3dny.Data.Models
{
    public class Customer : ApplicationUser
    {
        [Key]
        public int Id_Customer { get; set; }

        

        public ICollection<Requests> requests { get; set; }
        public ICollection<Review> reviews { get; set; }
    }
}