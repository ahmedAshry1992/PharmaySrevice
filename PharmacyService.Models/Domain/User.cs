using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public enum UsreType
    {
        systemAdmin=1,
        admin,
        user
    }
    public class User : Defaults
    {
        public UsreType role { get; set; }
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
        public int prancheId { get; set; }
        public int companyId { get; set; }
        [ForeignKey(nameof(companyId))]
        public Company company { get; set; }
        public List<Invoice> invoices { get; set; }
        public List<PurchaceInvoice> purchaceInvoices { get; set; }
        public List<ReturnedInvoice> returnedInvoices { get; set; }
        public List<Shift> shifts { get; set; }
    }
}
