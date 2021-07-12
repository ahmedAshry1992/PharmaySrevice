using PharmacyService.DataAccess.DomainRepository.IRepository.Services;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Services
{
    public class SupplierRepository: Repository<Supplier>, ISupplierReopsitory
    {
        private readonly MiddlewareDbContext context;

        public SupplierRepository (MiddlewareDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task Update(Supplier supplier)
        {
            var row = await context.Suppliers.FindAsync(supplier.id);
            row.name = supplier.name;
            row.phoneNumber = supplier.phoneNumber;           
            row.modifiedAt = DateTime.Now;
            row.modifiedBy = supplier.modifiedBy;
        }
    }
}
