using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class Customer : Defaults
    {
        public int prancheId { get; set; }
        [ForeignKey(nameof(prancheId))]
        public Pranche pranche { get; set; }
        public int companyId { get; set; }
        [Required]
        public string Name { set; get; }        
        [Required]      
        public string phoneNumber { set; get; }
        public string address { set; get; }
        public int? points { set; get; }
    }
}
