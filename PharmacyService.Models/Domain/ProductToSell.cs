using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class ProductToSell :Defaults
    {
        public int productId { get; set; }
        [ForeignKey(nameof(productId))]
        public Product product { get; set; }
        public int purchaceInvoiceDetailsId { get; set; }
        [ForeignKey(nameof(purchaceInvoiceDetailsId))]
        public PurchaceInvoiceDetails purchaceInvoiceDetails { get; set; }
        public bool exist { get; set; }
        public bool isBonus { get; set; }
        public bool returned { get; set; }
        public int returnedItems { get; set; }
        public int items { get; set; }
    }
}
