using Microsoft.EntityFrameworkCore;
using PharmacyService.DataAccess.DomainRepository.IRepository.ProductsManagement;
using PharmacyService.Models.API.Request.Invoice;
using PharmacyService.Models.API.Request.SalesManagement;
using PharmacyService.Models.API.Response.SalesManagement;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.ProductsManagement
{
    public class ProductToSellRepository : Repository<ProductToSell>, IProductToSellRepository
    {
        private readonly MiddlewareDbContext context;

        public ProductToSellRepository(MiddlewareDbContext context):base(context)
        {
            this.context = context;
        }
        public async Task<List<ProductToSell>> AddProductsFromPurInv(List<PurchaceInvoiceDetails> products, int userId)
        {
            List<ProductToSell> productsToSell = new List<ProductToSell>();
            foreach (var item in products)
            {
                for (int i = 0; i < item.quantity; i++)
                {
                    productsToSell.Add(new ProductToSell { productId = item.productId, purchaceInvoiceDetailsId = item.id, exist = true, returned = false, items = context.Products.Find(item.productId).largeUnits, returnedItems = 0, createdBy = userId });
                }
                
                if (item.bonus>0)
                {
                    for (int i = 0; i < item.bonus; i++)
                    {
                        productsToSell.Add(new ProductToSell { productId = item.productId, purchaceInvoiceDetailsId =item.id, exist = true, returned = false, items = context.Products.Find(item.productId).largeUnits, returnedItems = 0, createdBy = userId, isBonus=true });
                    }
                }
            }
            await context.ProductsToSell.AddRangeAsync(productsToSell);
            context.SaveChanges();
            return productsToSell;
        }

        public async Task<List<InventoryResponse>> Inventory(InventoryRequest request)
        {
            var result = await context.ProductsToSell.Where(x => request.productsToInventory.Contains(x.productId)).ToListAsync();
            var response = new List<InventoryResponse>();
            var invItem = new InventoryResponse();
            foreach (var item in result)
            {
                var p = request.itemsDetails.Find(x => x.productToSellId == item.id);
                if (!item.exist && p!=null)
                {
                    response.Add(new InventoryResponse { productId = item.productId , productToSellId = item.id, noItemsOnShelf = 0, noItemsOnSystem = item.items, missedItems = 0 - p.items });                    
                    
                }
                else
                {
                    if (p != null && item.exist)
                    {
                        response.Add(new InventoryResponse { productId=item.productId ,productToSellId = item.id, noItemsOnShelf = p.items, noItemsOnSystem = item.items, missedItems = item.items - p.items });
                        //if (p.items == item.items)
                        //{
                        //    response.Add(new InventoryResponse { productToSellId = item.id, noItemsOnShelf = p.items, noItemsOnSystem = item.items, missedItems = item.items - p.items });
                        //}
                        //else
                        //{
                        //    response.Add(new InventoryResponse { productToSellId = item.id, noItemsOnShelf = p.items, noItemsOnSystem = item.items, missedItems = item.items - p.items });
                        //}
                    }
                    else if(item.exist)
                    {
                        response.Add(new InventoryResponse { productId = item.productId, productToSellId = item.id, noItemsOnShelf = 0, noItemsOnSystem = item.items, missedItems = item.items - 0 });
                    }

                }
                
            }

            return response;

            
        }


        public async Task<List<ProductFilterResponse>> GetProductsMatchId(int request)
        {
            var products = context.Products.Where(x => !(x.isDeleted) && x.alive);
            var productToSell = context.ProductsToSell.Include(x => x.purchaceInvoiceDetails).Include(x => x.product).Where(x => x.exist);
          
            var prods = new List<ProductToSell>();
           
                prods = await productToSell.Where(x => (x.id == request)).ToListAsync();
          
            var result = new List<ProductFilterResponse>();
            foreach (var item in prods)
            {
                result.Add(new ProductFilterResponse { code = item.id, items = item.items, name = item.product.englishName, defualtItems=item.product.largeUnits, price = item.product.price, expiry = item.purchaceInvoiceDetails.expireDate });
            }
            return result;
        }

        public async Task<List<ProductFilterResponse>> GetProductsMatchName(string request)
        {
            var products = context.Products.Where(x => !(x.isDeleted) && x.alive);
            var productToSell = context.ProductsToSell.Include(x => x.purchaceInvoiceDetails).Include(x => x.product).Where(x => x.exist);
            var prods = new List<ProductToSell>();
            prods = await productToSell.Where(x => x.product.englishName.Contains(request)).ToListAsync();
            var result = new List<ProductFilterResponse>();
            foreach (var item in prods)
            {
                result.Add(new ProductFilterResponse { code = item.id, items = item.items, name = item.product.englishName, defualtItems = item.product.largeUnits, price = item.product.price, expiry = item.purchaceInvoiceDetails.expireDate });
            }
            return result;
        }
    }
}
