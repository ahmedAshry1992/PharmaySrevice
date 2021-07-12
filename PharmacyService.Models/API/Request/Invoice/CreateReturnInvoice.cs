using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Invoice
{
    public class CreateReturnInvoice
    {
        public int invoiceId { get; set; }        
        public int createdBy { get; set; }
        public List<ProductToReturn> productsToReturn { get; set; }
    }
    public class ProductToReturn
    {
        public int invoiceDetailsId { get; set; }
        public int numOfReturnedItems { get; set; }
    }

}
