using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Services
{
    public class ProductsCompanyRequest
    {
        public string companyName { get; set; }
        public string about { get; set; }
        public int id { get; set; }
        public bool isDeleted { get; set; }
        public int createdBy { get; set; }
        public int modifiedBy { get; set; }
    }
}
