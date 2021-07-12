using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Invoice
{
    public class PurchaceInvoiceFilterRequest
    {
        public int ctertedBy { get; set; }
        public int supplierId { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }

    }
}
