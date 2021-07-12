using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Management
{
    public class LogInRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
