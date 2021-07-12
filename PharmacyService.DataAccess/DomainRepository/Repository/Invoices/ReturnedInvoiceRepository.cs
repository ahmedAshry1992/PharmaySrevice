using Microsoft.EntityFrameworkCore;
using PharmacyService.DataAccess.DomainRepository.IRepository.Invoices;
using PharmacyService.Models.API.Request.Invoice;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Invoices
{
    public class ReturnedInvoiceRepository:Repository<ReturnedInvoice>, IReturnedInvoiceRepository
    {
        private readonly MiddlewareDbContext context;

        public ReturnedInvoiceRepository(MiddlewareDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> AddGetId(ReturnedInvoice returnedInvoice)
        {

            await context.ReturnedInvoices.AddAsync(returnedInvoice);
            context.SaveChanges();
            return returnedInvoice.id;
        }

        public async Task<List<ReturnedInvoice>> GetReturnedInvoiceByFilter(ReturnedInvoiceFilterRequest request)
        {
            var response = context.ReturnedInvoices.Where(x => !x.isDeleted);
            if (request.createdBy > 0)
            {
                response = response.Where(x => x.createdBy == request.createdBy);
            }
            
            if (request.fromDate != null)
            {
                response = response.Where(x => x.createdAt.Date >= request.fromDate.Value.Date);
            }
            if (request.toDate != null)
            {
                response = response.Where(x => x.createdAt.Date <= request.toDate.Value.Date);
            }
            return await response.ToListAsync();
        }
    }
}
