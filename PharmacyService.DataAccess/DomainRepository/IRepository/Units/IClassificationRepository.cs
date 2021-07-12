using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.Units
{
    public interface IClassificationRepository:IRepository<Classification>
    {
        Task Update(Classification classification);
    }
}
