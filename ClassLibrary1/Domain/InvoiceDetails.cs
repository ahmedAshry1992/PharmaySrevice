using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class InvoiceDetails:Defaults
    {
        public int invoiceId { get; set; }
        public int productToSellId { get; set; }
        public int items { get; set; }

    }
}
