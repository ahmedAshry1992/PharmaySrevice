using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Response.Invoice
{
    public class SalesInvoiceDetailsResponse
    {
        public int id { get; set; }
        public int invoiceId { get; set; }
        public int productToSellId { get; set; }
        public int productId { get; set; }
        public int items { get; set; }
    }
}
