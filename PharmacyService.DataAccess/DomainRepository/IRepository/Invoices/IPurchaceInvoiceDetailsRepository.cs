using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.Invoices
{
    public interface IPurchaceInvoiceDetailsRepository :IRepository<PurchaceInvoiceDetails>
    {
        Task<List<PurchaceInvoiceDetails>> AddManyItems(int invoicId, int userId, List<PurchaceInvoiceDetails> purchaces);
        Task<List<PurchaceInvoiceDetails>> GetInvoiceDetails(int id);
    }
}
