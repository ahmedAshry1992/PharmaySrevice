using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class PurchaceInvoiceDetails :Defaults
    {
        public int purchaceInvoiceId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public decimal purchacePrice { get; set; }
        public float discountPercentage { get; set; }
        public DateTime expireDate { get; set; }
    }
}
