using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string hireDate { set; get; }
        [Required]        
        public string phoneNumber { set; get; }
        [Required]
        public string email { get; set; }
        public byte[] passwordSalt { get; set; }
        public byte[] passwordHsh { get; set; }
    }
}
