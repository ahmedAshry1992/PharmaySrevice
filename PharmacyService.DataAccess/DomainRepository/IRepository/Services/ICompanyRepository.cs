using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.Services
{
    public interface ICompanyRepository:IRepository<Company>
    {
        Task<List<string>> ValidCompanyId(int id);
    }
}
