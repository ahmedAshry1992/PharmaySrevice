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
        //Task<List<int>> AddManyItems(int invoicId, int userId, List<InvoiceDetails> sales, List<int> ids);
        Task<int> AddManyItems(int invoicId, int userId, List<InvoiceDetails> sales);
        Task<InvoiceCreateResponse> SaveItems(int invoicId, int userId, List<InvoiceDetails> sales);
        Task<List<InvoiceDetails>> GetInvoiceDetails(int id);
        Task RemoveInvoiceDetailsItem(int id);
    }
}
