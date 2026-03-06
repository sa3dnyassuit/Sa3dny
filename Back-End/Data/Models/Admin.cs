using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sa3dny.Data.Models
{
    public class Admin
    {
        [Key]
        public int Admin_ID { get; set; }
        [Required]
        [DisplayName("Name")]
        public string Name_Admin { get; set; }
        public string Access { get; set; }
    }
}
