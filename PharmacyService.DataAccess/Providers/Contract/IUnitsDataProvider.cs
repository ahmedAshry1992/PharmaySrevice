using PharmacyService.DataAccess.DomainRepository.IRepository.Units;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.Providers.Contract
{
    public interface IUnitsDataProvider:IDisposable
    {
        public IClassificationRepository Classification { get;  }
        public IDosageFormRepository DosageForm { get;  }
        public ILargeUnitTypeRepository LargeUnitType { get;  }
        public ISmallUnitTypeRepository SmallUnitType { get;  }
        Task Save();
    }
}
