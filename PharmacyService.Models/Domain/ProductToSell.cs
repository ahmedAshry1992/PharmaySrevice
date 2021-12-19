using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class ProductToSell :Defaults
    {       
        public int? prancheId { get; set; }
        [ForeignKey(nameof(prancheId))]
        public Pranche pranche { get; set; }
        public int companyId { get; set; }      
        public int? productInPranchetId { get; set; }
        [ForeignKey(nameof(productInPranchetId))]
        public ProductInPranche productInPranche { get; set; }        
        public int? purchaceInvoiceDetailsId { get; set; }
        [ForeignKey(nameof(purchaceInvoiceDetailsId))]
        public PurchaceInvoiceDetails purchaceInvoiceDetails { get; set; }
        public bool exist { get; set; }
        public bool isBonus { get; set; }
        public bool returned { get; set; }
        public int returnedItems { get; set; }
        public int items { get; set; }
    }
}
