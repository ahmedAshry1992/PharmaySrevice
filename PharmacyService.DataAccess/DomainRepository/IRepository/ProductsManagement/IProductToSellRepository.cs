using PharmacyService.Models.API.Request.Invoice;
using PharmacyService.Models.API.Request.SalesManagement;
using PharmacyService.Models.API.Response.SalesManagement;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.ProductsManagement
{
    public interface IProductToSellRepository:IRepository<ProductToSell>
    {
        Task<List<ProductToSell>> AddProductsFromPurInv(List<PurchaceInvoiceDetails> products, int userId);
        Task<List<InventoryResponse>> Inventory(InventoryRequest request);
        Task<List<ProductFilterResponse>> GetProductsMatchId(int request);
        Task<List<ProductFilterResponse>> GetProductsMatchName(string request);
    }
}
