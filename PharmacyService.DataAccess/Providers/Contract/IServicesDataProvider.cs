using PharmacyService.DataAccess.DomainRepository.IRepository.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.Providers.Contract
{
    public interface IServicesDataProvider:IDisposable
    {
        public IShiftRepository Shift { get;  }
        public ISupplierReopsitory Supplier { get; }
        public IUserRepository User { get;  }
        public ICustomerRepository Customer { get; }
        
        Task Save();
    }
}
