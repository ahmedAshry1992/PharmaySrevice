using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.ProductsManagement
{
    public interface IProductRepository: IRepository<Product>
    {
        Task Update(Product product);
        Task<List<Product>> Search(string filter);
    }
}
