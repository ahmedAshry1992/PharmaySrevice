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
    public class PurchaceInvoiceRepository: Repository<PurchaceInvoice>, IPurchaceInvoiceRepository
    {
        private readonly MiddlewareDbContext context;

        public PurchaceInvoiceRepository(MiddlewareDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<List<string>> ValidatePurchaseInvoiceRequest(CreatePuchaceInvoice request)
        {
            var messages = new List<string>();
            foreach (var item in request.purchaces)
            {
                var product = await context.Products.FindAsync(item.productId);
                if (product != null)
                {
                    if (!product.alive)
                    {
                        messages.Add(product.englishName + " " + "Not alive");
                    }
                    
                }
                else messages.Add( "Not found product");
            }
            return messages;
        }
        public async Task<int> AddGetId(PurchaceInvoice purchaceInvoice)
        {
            
            await context.PurchaceInvoices.AddAsync(purchaceInvoice);
            context.SaveChanges();
            return purchaceInvoice.id ;
        }

        public async Task<List<PurchaceInvoice>> GetPurchaceInvoiceByFilter (PurchaceInvoiceFilterRequest request)
        {
            var response = context.PurchaceInvoices.Where(x => !x.isDeleted);
            if (request.ctertedBy>0)
            {
                response = response.Where(x => x.createdBy == request.ctertedBy);
            }
            if (request.supplierId>0)
            {
                response = response.Where(x => x.supplierId == request.supplierId);
            }
            if (request.fromDate!=null)
            {
                response = response.Where(x => x.createdAt.Date >= request.fromDate.Value.Date);
            }
            if (request.toDate!=null)
            {
                response = response.Where(x => x.createdAt.Date <= request.toDate.Value.Date);
            }
            return await response.ToListAsync();
        }
    }
}
