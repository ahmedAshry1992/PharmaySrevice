using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Response.Invoice
{
    public class SalesInvioceResponse
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int? customerId { get; set; }
        public int statusId { get; set; }
        public int typeId { get; set; }
        public DateTime createdAt { get; set; }
    }
}
