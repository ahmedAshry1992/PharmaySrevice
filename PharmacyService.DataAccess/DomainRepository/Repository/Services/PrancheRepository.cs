using PharmacyService.DataAccess.DomainRepository.IRepository.Services;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Services
{
    public class PrancheRepository:Repository<Pranche>, IPrancheRepository
    {
        private readonly MiddlewareDbContext context;

        public PrancheRepository(MiddlewareDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
