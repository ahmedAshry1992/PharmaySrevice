using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Management
{
    public class SupplierRequest
    {
        public int id { get; set; }
        public string name { set; get; }
        public string phoneNumber { set; get; }
        public int modifiedBy { get; set; }
        public int createdBy { get; set; }
    }
}
