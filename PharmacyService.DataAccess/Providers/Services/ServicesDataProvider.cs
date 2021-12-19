using PharmacyService.DataAccess.DomainRepository;
using PharmacyService.DataAccess.DomainRepository.IRepository.Services;
using PharmacyService.DataAccess.DomainRepository.Repository.Services;
using PharmacyService.DataAccess.Providers.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.Providers.Services
{
    public class ServicesDataProvider : IServicesDataProvider
    {
        private readonly MiddlewareDbContext _db;

        public ServicesDataProvider(MiddlewareDbContext context)
        {
            _db = context;
            Shift = new ShiftRepository(_db);
            Supplier = new SupplierRepository (_db);
            User = new UserRepository(_db);
            Customer = new CustomerRepository(_db);
            Company = new CompanyRepository(_db);
            Pranche = new PrancheRepository(_db);
           
        }
        public IShiftRepository Shift { get; private set; }

        public ISupplierReopsitory Supplier { get; private set; }

        public IUserRepository User { get; private set; }
        public ICustomerRepository Customer { get; private set; }

        public ICompanyRepository Company { get; private set; }

        public IPrancheRepository Pranche { get; private set; }
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
