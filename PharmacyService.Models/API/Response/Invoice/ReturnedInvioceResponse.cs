using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Response.Invoice
{
    public class ReturnedInvioceResponse
    {
        public int id { get; set; }
        public int createdBy { get; set; }
        public int invoiceId { get; set; }
        public DateTime createdAt { get; set; }
    }
}
