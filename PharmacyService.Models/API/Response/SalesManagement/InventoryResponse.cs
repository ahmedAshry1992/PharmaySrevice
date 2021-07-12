using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Response.SalesManagement
{
    public class InventoryResponse
    {
        public int productToSellId { get; set; }
        public int productId { get; set; }
        public int noItemsOnSystem { get; set; }
        public int noItemsOnShelf { get; set; }
        public int missedItems { get; set; }
    }
}
