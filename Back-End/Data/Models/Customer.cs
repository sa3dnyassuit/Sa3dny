using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sa3dny.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id_Customer { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name_Customer { get; set; }
        [Required]
        [DisplayName("Address")]
        public string Address_Customer { get; set; }
        [Required]
        [DisplayName("Phone")]
        public string phone_Customer { get; set; }
 
        public DateTime? created_at { get; set; }


    }
}
