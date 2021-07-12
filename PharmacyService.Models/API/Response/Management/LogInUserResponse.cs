using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Response.Management
{
    public class LogInUserResponse
    {
        public int id { get; set; }
        public string email { get; set; }
        public string firstName { set; get; }
    }
}
