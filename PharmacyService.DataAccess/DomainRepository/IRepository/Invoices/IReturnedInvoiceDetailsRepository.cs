using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.Invoices
{
    public interface IReturnedInvoiceDetailsRepository: IRepository<ReturnedInvoiceDetails>
    {
        Task AddManyItems(int retunedinvoicId, int userId, List<ReturnedInvoiceDetails> retuns);
        Task<List<ReturnedInvoiceDetails>> GetReturnedInvoiceDetails(int id);
    }
}
