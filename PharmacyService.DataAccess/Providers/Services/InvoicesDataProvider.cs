using PharmacyService.DataAccess.DomainRepository;
using PharmacyService.DataAccess.DomainRepository.IRepository.Invoices;
using PharmacyService.DataAccess.DomainRepository.Repository.Invoices;
using PharmacyService.DataAccess.Providers.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.Providers.Services
{
    public class InvoicesDataProvider : IInvoicesDataProvider
    {
        private readonly MiddlewareDbContext _db;

        public InvoicesDataProvider(MiddlewareDbContext context)
        {
            _db = context;
            InvoiceDetails = new InvoiceDetailsRepository(_db);
            Invoice = new InvoiceRepository(_db);
            PurchaceInvoiceDetails = new PurchaceInvoiceDetailsRepository(_db);
            PurchaceInvoice = new PurchaceInvoiceRepository(_db);
            ReturnedInvoiceDetails = new ReturnedInvoiceDetailsRepository(_db);
            ReturnedInvoice = new ReturnedInvoiceRepository(_db);
            InvoiceType = new InvoiceTypeRepository(_db);
            InvoiceStatus = new InvoiceStatusRepository(_db);

        }
        public IInvoiceDetailsRepository InvoiceDetails { get; private set; }

        public IInvoiceRepository Invoice { get; private set; }

        public IPurchaceInvoiceDetailsRepository PurchaceInvoiceDetails { get; private set; }

        public IPurchaceInvoiceRepository PurchaceInvoice { get; private set; }

        public IReturnedInvoiceDetailsRepository ReturnedInvoiceDetails { get; private set; }

        public IReturnedInvoiceRepository ReturnedInvoice { get; private set; }
        public IInvoiceTypeRepository InvoiceType { get; private set; }
        public IInvoiceStatusRepository InvoiceStatus { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
