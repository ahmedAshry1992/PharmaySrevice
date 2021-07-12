using PharmacyService.DataAccess.DomainRepository.IRepository.Units;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Units
{
    public class ClassificationRepository:Repository<Classification> , IClassificationRepository
    {
        private readonly MiddlewareDbContext context;

        public ClassificationRepository(MiddlewareDbContext context):base(context)
        {
            this.context = context;
        }
        public async Task Update(Classification classification)
        {
            var form = await context.Classifictions.FindAsync(classification.id);
            form.classification = classification.classification;
            form.modifiedAt = DateTime.Now;
            form.modifiedBy = classification.modifiedBy;
        }
    }
}
