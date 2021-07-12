using Microsoft.EntityFrameworkCore;
using PharmacyService.DataAccess.DomainRepository.IRepository.Invoices;
using PharmacyService.Models.API.Response.Invoice;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Invoices
{
    public class InvoiceDetailsRepository : Repository<InvoiceDetails>, IInvoiceDetailsRepository
    {
        private readonly MiddlewareDbContext context;

        public InvoiceDetailsRepository(MiddlewareDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<InvoiceCreateResponse> AddManyItems(int invoicId, int userId, List<InvoiceDetails> sales)
        {
            foreach (var item in sales)
            {
                item.invoiceId= invoicId;
                item.createdBy = userId;

            }
            ProductToSell product = new ProductToSell();
            InvoiceCreateResponse invoiceCreateResponse = new InvoiceCreateResponse();
            List<InvoiceSales> invoiceSales = new List<InvoiceSales>();
            float total = 0;
            float productPrice = 0;
            foreach (var item in sales)
            {
                product = context.ProductsToSell.Find(item.productToSellId);
                if (product.exist && product.items >= item.items)
                {
                    var pItems = context.Products.Find(product.productId);
                    if (item.discount > 0)
                    {
                        productPrice = pItems.price - (pItems.price * item.discount);
                    }
                    else productPrice = pItems.price;
                    invoiceSales.Add(new InvoiceSales
                    {
                        productName = pItems.englishName,
                        smallUnits = item.items == pItems.largeUnits ? 0 : item.items,
                        largeUnits = item.items == pItems.largeUnits ? 1 : 0,
                        price = productPrice * ((float)item.items / pItems.largeUnits),
                        discount=item.discount
                    });                    
                    total = total + ((float)productPrice * ((float)item.items / pItems.largeUnits));
                    product.items -= item.items;
                    product.modifiedBy = userId;
                    product.modifiedAt = DateTime.Now;
                    if (product.items == 0)
                    {
                        product.exist = false;
                    }

                }

            }
            await context.InvoicesDetails.AddRangeAsync(sales);
            context.SaveChanges();
            invoiceCreateResponse.invoiceSales = invoiceSales;
            invoiceCreateResponse.total = total;
            invoiceCreateResponse.id = invoicId;
            invoiceCreateResponse.createdDate = DateTime.Now;
            invoiceCreateResponse.userId = userId;
            return invoiceCreateResponse;
        }

        public async Task<List<InvoiceDetails>> GetInvoiceDetails(int id)
        {
            if (id != 0)
            {
                return await context.InvoicesDetails.Where(x => x.invoiceId == id && !x.isDeleted).ToListAsync();
            }
            return new List<InvoiceDetails>();
        }
    }
}
