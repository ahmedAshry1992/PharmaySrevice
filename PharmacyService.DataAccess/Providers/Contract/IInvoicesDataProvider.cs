using PharmacyService.DataAccess.DomainRepository.IRepository.Invoices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.Providers.Contract
{
    public interface IInvoicesDataProvider :IDisposable
    {
        public IInvoiceDetailsRepository InvoiceDetails { get; }
        public IInvoiceRepository Invoice { get; }
        public IPurchaceInvoiceDetailsRepository PurchaceInvoiceDetails { get; }
        public IPurchaceInvoiceRepository PurchaceInvoice { get; }
        public IReturnedInvoiceDetailsRepository ReturnedInvoiceDetails { get; }
        public IReturnedInvoiceRepository ReturnedInvoice { get; }
        public IInvoiceTypeRepository InvoiceType { get; }
        public IInvoiceStatusRepository InvoiceStatus { get; }
        Task Save();
    }
}
