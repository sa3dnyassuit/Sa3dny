using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sa3dny.Data.Models
{
    public class Review
    {
        [Key]
        public int Review_Id { get; set; }
        [ForeignKey(nameof(provider))]
        public int Provider_Id { get; set; }
        [ForeignKey(nameof(requests))]
        public int Request_Id { get; set; }
        [ForeignKey(nameof(customer))]
        public int Customer_Id { get; set; }

        public int Rate { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public Customer customer { get; set; }
        public Provider provider { get; set; }
        public Requests  requests { get; set; }
    }
}
