using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sa3dny.Data.Models
{
    public class Service
    {
        [Key]
        public int service_id { get; set; }
        [Required]
        [DisplayName("Service Name")]
        public string service_name { get; set; }
        [Required]
        [DisplayName("Service Description")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Service Min price")]
        public decimal Min_price { get; set; }
    }
}
