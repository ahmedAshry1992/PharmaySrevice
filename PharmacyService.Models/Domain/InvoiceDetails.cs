using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class InvoiceDetails:Defaults
    {
        public int invoiceId { get; set; }
        [ForeignKey(nameof(invoiceId))]
        public Invoice MyProperty { get; set; }
        public int productToSellId { get; set; }
        public int items { get; set; }
        public float discount { get; set; } 

    }
}
