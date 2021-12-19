using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Management
{
    public class CompanyCreateRequest
    {
        public CompanyRequest company { get; set; }
        public PrancheRequest pranche { get; set; }
        public UserRequest user { get; set; }
    }
    public class CompanyRequest
    {
        public int companyId { get; set; }
        public string name { get; set; }
        public string ownerName { get; set; }
        public int createdBy { get; set; }
    }
    public class PrancheRequest
    {
        public int pranchId { get; set; }
        public int companyId { get; set; }
        public string address { get; set; }
        public int createdBy { get; set; }
    }
}
