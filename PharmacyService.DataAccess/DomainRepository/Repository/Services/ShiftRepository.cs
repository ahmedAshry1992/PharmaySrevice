using PharmacyService.DataAccess.DomainRepository.IRepository.Services;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Services
{
    public class ShiftRepository:Repository<Shift>, IShiftRepository
    {
        private readonly MiddlewareDbContext context;

        public ShiftRepository (MiddlewareDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
