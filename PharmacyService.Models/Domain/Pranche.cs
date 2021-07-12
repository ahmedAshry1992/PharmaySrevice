using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class Pranche 
    {
        [Key]        
        public  int pranchId { get; set; }
        public int companyId { get; set; }
        [ForeignKey(nameof(companyId))]
        public Company company { get; set; }
        public string address { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime createdAt { get; set; }

        public int createdBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime modifiedAt { get; set; }

        public int modifiedBy { get; set; }

        public bool isDeleted { get; set; }
        

        public Pranche()
        {
            this.createdAt = DateTime.Now;
            this.modifiedAt = DateTime.Now;
            this.createdBy = -1;
            this.modifiedBy = -1;
            this.isDeleted = false;
        }
    }
}
