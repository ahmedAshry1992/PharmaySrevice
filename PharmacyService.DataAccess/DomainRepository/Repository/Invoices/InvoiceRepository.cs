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
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly MiddlewareDbContext context;

        public InvoiceRepository(MiddlewareDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<List<string>> ValidateInvoiceRequest(CreateSalesInvoice request)
        {
            var messages = new List<string>();
            foreach (var item in request.salesProducts)
            {
                var product = await context.ProductsToSell.FindAsync(item.productToSellId);
                if (product!=null)
                {
                    if (!product.exist)
                    {
                        messages.Add(item.productToSellId.ToString() + " " + "Sold out");
                    }
                    if (product.exist && !(product.items>=item.items))
                    {
                        messages.Add(item.productToSellId.ToString() + " " + "Not enough");
                    }
                }
                else messages.Add(item.productToSellId.ToString() + " " + "Not Found");
            }
            return messages;
        }

        public async Task<int> AddGetId(Invoice invoice)
        {
            invoice.createdBy = invoice.userId;
            await context.Invoices.AddAsync(invoice);
            context.SaveChanges();
            return invoice.id;
        }

        public async Task update(Invoice invoice)
        {
            var result= await context.Invoices.FindAsync(invoice.id);
            result.modifiedBy = invoice.userId;
            result.typeId = invoice.typeId;
            result.statusId = invoice.statusId;
            result.customerId = invoice.customerId;
            result.modifiedAt = DateTime.Now;
            context.SaveChanges();
            
        }
        public async Task<List<Invoice>> GetSalesInvoiceByFilter(SalesInvoiceFilterRequest request)
        {
            var response = context.Invoices.Where(x => !x.isDeleted);
            if (request.userId > 0)
            {
                response = response.Where(x => x.userId == request.userId);
            }
            if (request.customerId > 0)
            {
                response = response.Where(x => x.customerId == request.customerId);
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
