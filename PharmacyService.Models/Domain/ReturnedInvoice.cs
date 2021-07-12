
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class ReturnedInvoice:Defaults
    {
        public int invoiceId { get; set; }
        public List<ReturnedInvoiceDetails> returnedInvoicesDetails { get; set; }



    }
}
