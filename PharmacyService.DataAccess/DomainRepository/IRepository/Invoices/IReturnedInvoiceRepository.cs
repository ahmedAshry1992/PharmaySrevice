using PharmacyService.Models.API.Request.Invoice;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.Invoices
{
    public interface IReturnedInvoiceRepository:IRepository<ReturnedInvoice>
    {
        Task<int> AddGetId(ReturnedInvoice returnedInvoice);
        Task<List<ReturnedInvoice>> GetReturnedInvoiceByFilter(ReturnedInvoiceFilterRequest request);
    }
}
