using Microsoft.EntityFrameworkCore;
using PharmacyService.DataAccess.DomainRepository.IRepository.Services;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Services
{
    public class CompanyRepository:Repository<Company>, ICompanyRepository
    {
        private readonly MiddlewareDbContext context;

        public CompanyRepository(MiddlewareDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<List<string>> ValidCompanyId(int id)
        {
            var errorMessages = new List<string>();
            if (!await context.Companies.AnyAsync(x => x.companyId == id))
            {
                errorMessages.Add("Not exist company");
                return errorMessages;
            }
           
            if ((await context.Companies.FindAsync(id)).isDeleted)
                errorMessages.Add("Company is deleted");
            return errorMessages;


        }
    }
}
