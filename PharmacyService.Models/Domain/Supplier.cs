using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class Supplier:Defaults
    {
        [Required]        
        public string name { set; get; }
        [Required]        
        public string phoneNumber { set; get; }
    }
}
