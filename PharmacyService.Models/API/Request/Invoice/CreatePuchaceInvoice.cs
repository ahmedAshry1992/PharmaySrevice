using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Invoice
{
    public class CreatePuchaceInvoice
    {
        public int id { get; set; }
        public int supplierId { get; set; }
        public int createdBy { get; set; }
        public List<PurchaceaianvoiceModel> purchaces { get; set; }
    }
    public class PurchaceaianvoiceModel
    {
        public int productId { get; set; }
        public int quantity { get; set; }
        public int bonus { get; set; }
        public DateTime expireDate { get; set; }
        public decimal purchacePrice { get; set; }
        public float discountPercentage { get; set; }
    }
}
