using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.Services
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task Update(Customer customer);
    }
}
