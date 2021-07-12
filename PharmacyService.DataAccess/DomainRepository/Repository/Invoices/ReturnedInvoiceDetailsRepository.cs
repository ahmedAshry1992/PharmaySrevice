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
    public class ReturnedInvoiceDetailsRepository: Repository<ReturnedInvoiceDetails>, IReturnedInvoiceDetailsRepository
    {
        private readonly MiddlewareDbContext context;

        public ReturnedInvoiceDetailsRepository (MiddlewareDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task AddManyItems(int retunedinvoicId, int userId, List<ReturnedInvoiceDetails> retuns)
        {
            foreach (var item in retuns)
            {
                item.returnedInvoiceId = retunedinvoicId;
                item.createdBy = userId;
            }

            foreach (var item in retuns)
            {
                var soldItemInv=await context.InvoicesDetails.FindAsync(item.invoiceDetailsId);
                var soldItem = await context.ProductsToSell.FindAsync(soldItemInv.productToSellId);
                //soldItemInv.isDeleted = true;
                soldItem.items += item.numOfReturnedItems;
                if (!soldItem.exist)
                {
                    soldItem.exist = true;
                }
                if (!soldItem.returned)
                {
                    soldItem.returned = true;                    
                }
                soldItem.returnedItems += item.numOfReturnedItems;
                soldItem.modifiedAt = DateTime.Now;
                soldItem.modifiedBy = userId;
                soldItem.returnedItems = item.numOfReturnedItems;

                item.createdAt = DateTime.Now;
                item.createdBy = userId;
                item.isDeleted = false;
                item.numOfReturnedItems = item.numOfReturnedItems;

                context.ReturnedInvoicesDetails.Add(item) ;

                //soldItemInv.modifiedAt = DateTime.Now;
              //  soldItemInv.modifiedBy = userId;

            }
            context.SaveChanges();
        }

        public async Task<List< ReturnedInvoiceDetails>> GetReturnedInvoiceDetails(int id)
        {
            if (id != 0)
            {
                return await context.ReturnedInvoicesDetails.Where(x => x.returnedInvoiceId == id && !x.isDeleted).ToListAsync();
            }
            return new List<ReturnedInvoiceDetails>();
        }


    }
}
