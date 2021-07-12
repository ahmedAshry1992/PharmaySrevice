using PharmacyService.DataAccess.DomainRepository.IRepository.Units;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Units
{
    public class SmallUnitTypeRepository:Repository<SmallUnitType>, ISmallUnitTypeRepository
    {
        private readonly MiddlewareDbContext context;
        public SmallUnitTypeRepository(MiddlewareDbContext context) : base(context)
        {
            this.context = context;
        }


        public async Task Update(SmallUnitType smallUnitType)
        {
            var form = await context.SmallUnitTypes.FindAsync(smallUnitType.id);
            form.type = smallUnitType.type;
            form.modifiedAt = DateTime.Now;
            form.modifiedBy = smallUnitType.modifiedBy;
        }
    }
}
