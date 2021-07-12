
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Management
{
    public class UserRequest
    {
        public int id { get; set; }
        public string firstName { set; get; }        
        public string lastName { set; get; }        
        public DateTime hireDate { set; get; }        
        public string phoneNumber { set; get; }        
        public string email { get; set; }
        public string password { get; set; }
        public int createdBy { get; set; }
    }
}
