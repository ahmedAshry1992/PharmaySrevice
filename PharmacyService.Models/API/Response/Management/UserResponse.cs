using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Response.Management
{
    public class UserResponse
    {
        public int id { get; set; }
        public UsreType role { get; set; }
        public int prancheId { get; set; }
        public int companyId { get; set; }
        public bool isActive { get; set; }
        public string firstName { set; get; }        
        public string lastName { set; get; }        
        public DateTime hireDate { set; get; }        
        public string phoneNumber { set; get; }        
        public string email { get; set; }
    }
}
