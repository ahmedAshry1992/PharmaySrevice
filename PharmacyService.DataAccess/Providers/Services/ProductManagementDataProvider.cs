using PharmacyService.DataAccess.DomainRepository;
using PharmacyService.DataAccess.DomainRepository.IRepository.ProductsManagement;
using PharmacyService.DataAccess.DomainRepository.Repository.ProductsManagement;
using PharmacyService.DataAccess.Providers.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.Providers.Services
{
    public class ProductManagementDataProvider : IProductManagementDataProvider
    {
        private readonly MiddlewareDbContext _db;

        public ProductManagementDataProvider(MiddlewareDbContext context) 
        {
            _db = context;
            Product =new ProductRepository(_db);
            ProductToSell = new ProductToSellRepository(_db);
            ProductsCompany = new ProductsCompanyRepository(_db);
        }
        public IProductRepository Product { get; private set; }

        public IProductToSellRepository ProductToSell { get; private set; }
        public IProductsCompanyRepository ProductsCompany { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
