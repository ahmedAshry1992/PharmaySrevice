using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class Customer : Defaults
    {
        [Required]
        public string firstName { set; get; }
        [Required]
        public string lastName { set; get; }
        [Required]      
        public string phoneNumber { set; get; }
        public string address { set; get; }
        public int? points { set; get; }
    }
}
