using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Response.Invoice
{
    public class PurchaceInvioceResponse
    {
        public int id { get; set; }
        public int supplierId { get; set; }
        public int createdBy { get; set; }
        public DateTime createdAt { get; set; }
    }
}
