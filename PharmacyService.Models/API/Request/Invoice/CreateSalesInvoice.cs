using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Invoice
{
    public class CreateSalesInvoice
    {
        public int userId { get; set; }
        public int? customerId { get; set; }
        public int statusId { get; set; }
        public int typeId { get; set; }
        public List<SalesInvoiceModel> salesProducts { get; set; }
    }
    public class SalesInvoiceModel
    {
        public int invoiceId { get; set; }
        public int productToSellId { get; set; }
        public float discount { get; set; }
        public int items { get; set; }
    }
}
