using PharmacyService.DataAccess.DomainRepository.IRepository.Services;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Services
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly MiddlewareDbContext context;

        public CustomerRepository (MiddlewareDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task Update(Customer customer)
        {
            var row = await context.Customers.FindAsync(customer.id);
            row.address = customer.address;
            row.Name = customer.Name;
           // row.lastName = customer.lastName;
            row.phoneNumber = customer.phoneNumber;
            row.modifiedAt = DateTime.Now;
            row.modifiedBy = customer.modifiedBy;
        }
    }
}
