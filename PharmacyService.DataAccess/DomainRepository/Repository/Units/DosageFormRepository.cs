using PharmacyService.DataAccess.DomainRepository.IRepository.Units;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.Units
{
    public class DosageFormRepository:Repository<DosageForm>, IDosageFormRepository
    {
        private readonly MiddlewareDbContext context;

        public DosageFormRepository(MiddlewareDbContext context):base(context)
        {
            this.context = context;
        }
        public async Task Update(DosageForm dosageForm)
        {
            var form = await context.DosageForms.FindAsync(dosageForm.id);
            form.form = dosageForm.form;
            form.modifiedAt = DateTime.Now;
            form.modifiedBy = dosageForm.modifiedBy;
        }


    }
}
