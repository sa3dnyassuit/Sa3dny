using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;

namespace Sa3dny.Data.Models
{
    public class Provider_Service
    {
        public int provider_id { get; set; }
        public int service_id { get; set; }
        public Provider Provider { get; set; }
        public Service Service { get; set; }
    }
}
