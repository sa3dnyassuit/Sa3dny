using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sa3dny.Api.DTOs.Requests
{
    public class AdminUpdateRequestDto
    {
        public int Request_Id { get; set; }

        public string Description_Req { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
        public int Service_Id { get; set; }

        public string Status { get; set; }
    }
}
