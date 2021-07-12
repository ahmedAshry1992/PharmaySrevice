using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class ReturnedInvoiceDetails:Defaults
    {
        public int returnedInvoiceId { get; set; }
        [ForeignKey(nameof(returnedInvoiceId))]
        public ReturnedInvoice  returnedInvoice { get; set; }
        public int invoiceDetailsId { get; set; }
        public int numOfReturnedItems { get; set; }


    }
}
