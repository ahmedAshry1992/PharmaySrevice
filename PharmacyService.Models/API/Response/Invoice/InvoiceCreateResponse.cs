using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.API.Response.Invoice
{
    public class InvoiceCreateResponse
    {
        public int id { get; set; }
        public DateTime createdDate { get; set; }
        public int userId { get; set; }
        public List<InvoiceSales> invoiceSales { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal total { get; set; }
    }
    public class InvoiceSales
    {
        public string productName { get; set; }
        public int largeUnits { get; set; }
        public int smallUnits { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }
        public float discount { get; set; }
    }
}
