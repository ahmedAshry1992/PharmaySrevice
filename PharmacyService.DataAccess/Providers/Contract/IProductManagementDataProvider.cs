using PharmacyService.DataAccess.DomainRepository.IRepository.ProductsManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.Providers.Contract
{
    public interface IProductManagementDataProvider:IDisposable
    {
        public IProductRepository Product { get;  }
        public IProductToSellRepository ProductToSell { get;  }
        public IProductsCompanyRepository ProductsCompany { get; }
        public IProductInPrancheRrepository ProductInPranche { get; }
        Task Save();

    }
}
