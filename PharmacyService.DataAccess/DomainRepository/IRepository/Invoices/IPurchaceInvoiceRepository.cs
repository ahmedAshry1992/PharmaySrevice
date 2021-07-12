using PharmacyService.Models.API.Request.Invoice;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.Invoices
{
    public interface IPurchaceInvoiceRepository :IRepository<PurchaceInvoice>
    {
        Task<int> AddGetId(PurchaceInvoice purchaceInvoice);
        Task<List<PurchaceInvoice>> GetPurchaceInvoiceByFilter(PurchaceInvoiceFilterRequest request);
        Task<List<string>> ValidatePurchaseInvoiceRequest(CreatePuchaceInvoice request);
    }
}
