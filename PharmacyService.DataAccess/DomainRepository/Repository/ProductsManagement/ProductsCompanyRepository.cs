using PharmacyService.DataAccess.DomainRepository.IRepository.ProductsManagement;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.ProductsManagement
{
    public class ProductsCompanyRepository : Repository<ProductsCompany>, IProductsCompanyRepository
    {
        private readonly MiddlewareDbContext context;

        public ProductsCompanyRepository(MiddlewareDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task Update(ProductsCompany productsCompany)
        {
            var form = await context.ProductsCompanies.FindAsync(productsCompany.id);
            form.companyName = productsCompany.companyName;
            form.about = productsCompany.about;
            form.modifiedAt = DateTime.Now;
            form.modifiedBy = productsCompany.modifiedBy;
        }
    }
}
