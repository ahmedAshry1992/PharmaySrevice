using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class User : Defaults
    {
        [Required]        
        public string firstName { set; get; }
        [Required]
        public string lastName { set; get; }
        [DataType(DataType.Date)]        
        public DateTime hireDate { set; get; }
        [Required]        
        public string phoneNumber { set; get; }
        [Required]
        public string email { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; }
        
    }
}
