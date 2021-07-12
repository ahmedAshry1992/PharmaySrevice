using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class ProductToSell :Defaults
    {
        public int productId { get; set; }
        public int purchaceInvoiceId { get; set; }
        public bool exist { get; set; }
        public bool returned { get; set; }
        public int returnedItems { get; set; }
        public int items { get; set; }
    }
}
