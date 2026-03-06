using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sa3dny.Data.Models
{
    public class Provider
    {
        [Key]
        public int provider_id { get; set; }
        [Required]
        [DisplayName("Name")]
       public string name_Provider { get; set; }
        [Required]
        [DisplayName("Address")]
        public string address_Provider { get; set; }
        [Required]
        [DisplayName("National_ID")]
        [StringLength(14)]
        public int national_id_Provider { get; set; }
        [DisplayName("Rate")]
        public double? rate_Provider { get; set; }
        public DateTime created_at { get; set; }
    }
}
