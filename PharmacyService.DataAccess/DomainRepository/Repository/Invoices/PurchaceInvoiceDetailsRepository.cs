using Microsoft.EntityFrameworkCore;
using PharmacyService.DataAccess.DomainRepository.IRepository.Invoices;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Invoices
{
    public class PurchaceInvoiceDetailsRepository :Repository<PurchaceInvoiceDetails>, IPurchaceInvoiceDetailsRepository
    {
        private readonly MiddlewareDbContext context;

        public PurchaceInvoiceDetailsRepository(MiddlewareDbContext context):base(context)
        {
            this.context = context;
        }
        public async Task<List<PurchaceInvoiceDetails>> AddManyItems(int invoicId, int userId, List<PurchaceInvoiceDetails> purchaces)
        {
            var ids = new List<int>();
            foreach (var item in purchaces)
            {
                item.purchaceInvoiceId = invoicId;
                item.createdBy = userId;
                
            }
           await context.PurchaceInvoicesDetails.AddRangeAsync(purchaces);
            context.SaveChanges();
            
            return purchaces;
        }


        public async Task<List<PurchaceInvoiceDetails>> GetInvoiceDetails(int id)
        {
            if (id != 0)
            {
                return await context.PurchaceInvoicesDetails.Where(x => x.purchaceInvoiceId == id && !x.isDeleted).ToListAsync();
            }
            return new List<PurchaceInvoiceDetails>();
        }
    }
}
