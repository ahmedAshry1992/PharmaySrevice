using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Response.Invoice
{
    public class ReturnedInvoiceDetailsResponse
    {
        public int ReturnedInvoiceId { get; set; }
        public int invoiceDetailsId { get; set; }
        public int productToSellId { get; set; }
        public int productId { get; set; }
    }
}
