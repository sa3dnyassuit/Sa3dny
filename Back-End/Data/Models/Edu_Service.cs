using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sa3dny.Data.Models
{
    public class Edu_Service
    {
        [Key]
        [ForeignKey(nameof(service))]
        public int Service_Id { get; set; }
        [Required]
        public string Type_service { get; set; }
        [Required]
        public string Category_name { get; set; }
        public Service service { get; set; }
    }
}
