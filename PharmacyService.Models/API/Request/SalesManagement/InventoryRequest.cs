using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.SalesManagement
{
    public class InventoryRequest
    {
        public List<int> productsToInventory { get; set; }
        public List<ItemDetails> itemsDetails { get; set; }
    }
    public class ItemDetails
    {
        public int productToSellId { get; set; }
        public int items { get; set; }
    }
}
