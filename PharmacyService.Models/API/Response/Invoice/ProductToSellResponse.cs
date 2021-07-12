using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Response.Invoice
{
    public class ProductToSellResponse
    {
        public int productId { get; set; }
        public int purchaceInvoiceDetailsId { get; set; }        
        public bool exist { get; set; }
        public bool isBonus { get; set; }
        public bool returned { get; set; }
        public int returnedItems { get; set; }
        public int items { get; set; }
    }
}
