using PharmacyService.DataAccess.DomainRepository.IRepository.Invoices;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Invoices
{
    class InvoiceTypeRepository: Repository<InvoiceType>, IInvoiceTypeRepository
    {
        private readonly MiddlewareDbContext context;
        public InvoiceTypeRepository(MiddlewareDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
