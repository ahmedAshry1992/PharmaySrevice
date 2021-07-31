using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Invoice
{
    public class EditSalesInvoiceRequest
    {
        public CreateSalesInvoice salesInvoiceRequest { get; set; }
        //public List<int> ids { get; set; }
    }
}
