using PharmacyService.DataAccess.DomainRepository.IRepository.ProductsManagement;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.ProductsManagement
{
    public class ProductInPrancheRepository: Repository<ProductInPranche>,IProductInPrancheRrepository
    {
        private readonly MiddlewareDbContext context;

        public ProductInPrancheRepository(MiddlewareDbContext context):base(context)
        {
            this.context = context;
        }  
        

        public async Task UpdateProductInPranche(ProductInPranche request)
        {
            var product=await context.productsInPranche.FindAsync(request.id);
            product.modifiedAt = DateTime.Now;
            product.modifiedBy = request.createdBy;
            product.newPrice = request.newPrice;
            await context.SaveChangesAsync();
        }
    }
}

