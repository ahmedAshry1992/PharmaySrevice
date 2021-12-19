using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.ProductsManagement
{
    public interface IProductInPrancheRrepository:IRepository<ProductInPranche>
    {
        Task UpdateProductInPranche(ProductInPranche request);
    }
}
