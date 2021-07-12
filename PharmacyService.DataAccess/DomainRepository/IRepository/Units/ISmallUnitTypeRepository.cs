using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.Units
{
    public interface ISmallUnitTypeRepository:IRepository<SmallUnitType>
    {
        Task Update(SmallUnitType smallUnitType);
    }
}
