using PharmacyService.Models.API.Response.Invoice;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.Invoices
{
    public interface IInvoiceDetailsRepository : IRepository<InvoiceDetails>
    {
        Task<InvoiceCreateResponse> AddManyItems(int invoicId, int userId, List<InvoiceDetails> sales);
        Task<List<InvoiceDetails>> GetInvoiceDetails(int id);
    }
}
