using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Management
{
    public class CustomerRequest
    {
        public int id { get; set; }
        public string Name { set; get; }        
        //public string lastName { set; get; }        
        public string phoneNumber { set; get; }
        public string address { set; get; }
        public int? points { set; get; }
        public int modifiedBy { get; set; }
        public int createdBy { get; set; }
    }
}
