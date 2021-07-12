using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Services
{
    public class ClassificationRequest
    {
        public string classification { set; get; }
        public int id { get; set; }
        public bool isDeleted { get; set; }
        public int createdBy { get; set; }
        public int modifiedBy { get; set; }
    }
}
