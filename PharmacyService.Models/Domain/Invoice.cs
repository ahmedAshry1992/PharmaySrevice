using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class Invoice: Defaults
    {
        public enum InvoiceStatus
        {
            saved,
            unsaved
        }
        public enum InvoiceType
        {
            fawry,
            delivery
        }
        
        public int? userId { get; set; }
        [ForeignKey(nameof(userId))]
        public User user { get; set; }       
        public int? prancheId { get; set; }
        [ForeignKey(nameof(prancheId))]
        public Pranche pranche { get; set; }
        public int companyId { get; set; }
        public int? customerId { get; set; }
        //public bool isSaved { get; set; }
        public InvoiceStatus statusId { get; set; }
        public InvoiceType typeId { get; set; }
        public List<InvoiceDetails> MyProperty { get; set; }

       

    }
}
