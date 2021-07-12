using PharmacyService.DataAccess.DomainRepository.IRepository.Invoices;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Invoices
{
    class InvoiceStatusRepository: Repository<InvoiceStatus>, IInvoiceStatusRepository
    {
        private readonly MiddlewareDbContext context;
        public InvoiceStatusRepository(MiddlewareDbContext context) : base(context)
        {
            this.context = context; 
        }
    }
}
