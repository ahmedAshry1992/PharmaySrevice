using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class Company
    {
        [Key]        
        public  int companyId { get; set; }
        public string name { get; set; }
        public string ownerName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime createdAt { get; set; }

        public int createdBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime modifiedAt { get; set; }

        public int modifiedBy { get; set; }

        public bool isDeleted { get; set; }
        public List<Pranche> pranches { get; set; }
        public List<User> users { get; set; }
        public List<Supplier> suppliers { get; set; }

        public Company()
        {
            this.createdAt = DateTime.Now;
            this.modifiedAt = DateTime.Now;
            this.createdBy = -1;
            this.modifiedBy = -1;
            this.isDeleted = false;
        }

    }
}
