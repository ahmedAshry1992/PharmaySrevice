using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class PurchaceInvoiceDetails :Defaults
    {
        public int purchaceInvoiceId { get; set; }
        [ForeignKey(nameof(purchaceInvoiceId))]
        public PurchaceInvoice purchaceInvoice { get; set; }
        public int productInPranchetId { get; set; }
        public int quantity { get; set; }
        public int bonus { get; set; }
        public decimal purchacePrice { get; set; }
        public float discountPercentage { get; set; }
        [DataType(DataType.Date)]
        public DateTime expireDate { get; set; }
        public List<ProductToSell> MyProperty { get; set; }
    }
}
