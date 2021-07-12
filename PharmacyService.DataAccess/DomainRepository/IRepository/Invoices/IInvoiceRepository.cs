using PharmacyService.Models.API.Request.Invoice;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.Invoices
{
    public interface IInvoiceRepository:IRepository<Invoice>
    {
        Task<int> AddGetId(Invoice invoice);
        Task<List<Invoice>> GetSalesInvoiceByFilter(SalesInvoiceFilterRequest request);
        Task<List<string>> ValidateInvoiceRequest(CreateSalesInvoice request);
    }
}
