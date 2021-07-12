using PharmacyService.Models.API.Request.Management;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.IRepository.Services
{
    public interface IUserRepository: IRepository<User>
    {
        Task Update(User request);
        bool IsValidEmail(string email);
        List<string> ValidatePassword(string password);
        Task<List<string>> ValidUserId(int id);
    }
}
