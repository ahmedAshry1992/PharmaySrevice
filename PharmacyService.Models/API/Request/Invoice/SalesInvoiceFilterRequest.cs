using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Invoice
{
    public class SalesInvoiceFilterRequest
    {
        public int userId { get; set; }
        public int customerId { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
    }
}
