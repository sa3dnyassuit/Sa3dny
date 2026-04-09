using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sa3dny.Data.Models
{
    public class Requests
    {
        [Key]
        public int Request_Id { get; set; }
        [ForeignKey(nameof(customer))]
        public int Customer_Id { get; set; }
        [ForeignKey(nameof(provider))]
        public int Provider_Id { get; set; }
        [ForeignKey(nameof(service))]
        public int Service_Id { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public decimal Total_Price { get; set; }
        public string? Status { get; set; }
        [Required]
        public string Description_Req { get; set; }

        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public Customer customer { get; set; }
        public Provider provider { get; set; }
        public Service service  { get; set; }
        public ICollection <Review> reviews { get; set; }
    }
}
