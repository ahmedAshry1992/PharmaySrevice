using PharmacyService.DataAccess.DomainRepository;
using PharmacyService.DataAccess.DomainRepository.IRepository.Units;
using PharmacyService.DataAccess.DomainRepository.Repository.Units;
using PharmacyService.DataAccess.Providers.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.Providers.Services
{
    public class UnitsDataProvider : IUnitsDataProvider
    {
        private readonly MiddlewareDbContext _db;

        public UnitsDataProvider(MiddlewareDbContext context)
        {
            _db = context;
            Classification = new ClassificationRepository(_db);
            DosageForm = new DosageFormRepository(_db);
            LargeUnitType = new LargeUnitTypeRepository(_db);
            SmallUnitType = new SmallUnitTypeRepository(_db);
        }
        public IClassificationRepository Classification { get; private set; }

        public IDosageFormRepository DosageForm { get; private set; }

        public ILargeUnitTypeRepository LargeUnitType { get; private set; }

        public ISmallUnitTypeRepository SmallUnitType { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
