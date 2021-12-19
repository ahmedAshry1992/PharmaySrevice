using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class Supplier:Defaults
    {
        [Required]        
        public string name { set; get; }
        [Required]        
        public string phoneNumber { set; get; }
        public int companyId { get; set; }
        [ForeignKey(nameof(companyId))]
        public Company company { get; set; }
        
    }
}
