using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.SalesManagement
{
    public class ProductListToPrancheRerquest
    {
        public int prancheId { get; set; }
        public int companyId { get; set; }
        public int createdBy { get; set; }
        public int productId { get; set; }
        public decimal newPrice { get; set; }

    }    
    
}
