using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class ProductInPranche:Defaults
    {
        public int productId { get; set; }
        [ForeignKey(nameof(productId))]
        public Product product { get; set; }
        public int prancheId { get; set; }
        [ForeignKey(nameof(prancheId))]
        public Pranche pranche { get; set; }
        public int companyId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal newPrice { get; set; }
    }
}
