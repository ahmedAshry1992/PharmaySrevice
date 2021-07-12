using PharmacyService.DataAccess.DomainRepository.IRepository;
using PharmacyService.DataAccess.DomainRepository.IRepository.Units;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Units
{
    public class LargeUnitTypeRepository: Repository<LargeUnitType>,ILargeUnitTypeRepository
    {
        private readonly MiddlewareDbContext context;

        public LargeUnitTypeRepository(MiddlewareDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task Update(LargeUnitType largeUnitType)
        {
            var form = await context.LargeUnitTypes.FindAsync(largeUnitType.id);
            form.type = largeUnitType.type;
            form.modifiedAt = DateTime.Now;
            form.modifiedBy = largeUnitType.modifiedBy;
        }
    }
}
