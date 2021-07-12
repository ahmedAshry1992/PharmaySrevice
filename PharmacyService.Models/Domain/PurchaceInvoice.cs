using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class PurchaceInvoice : Defaults
    {
        public int supplierId { get; set; }
        public List<PurchaceInvoiceDetails> MyProperty { get; set; }
    }
}
