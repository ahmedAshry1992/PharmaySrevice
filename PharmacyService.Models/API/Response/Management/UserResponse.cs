using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Response.Management
{
    public class UserResponse
    {
        public string firstName { set; get; }        
        public string lastName { set; get; }        
        public DateTime hireDate { set; get; }        
        public string phoneNumber { set; get; }        
        public string email { get; set; }
    }
}
