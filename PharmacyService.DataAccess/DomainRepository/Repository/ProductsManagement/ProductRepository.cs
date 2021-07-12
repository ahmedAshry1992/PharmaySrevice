using Microsoft.EntityFrameworkCore;
using PharmacyService.DataAccess.DomainRepository.IRepository.ProductsManagement;
using PharmacyService.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyService.DataAccess.DomainRepository.Repository.ProductsManagement
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private readonly MiddlewareDbContext context;

        public ProductRepository(MiddlewareDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task Update(Product product)
        {
            var pro= await context.Products.FindAsync(product.id);
            pro.alive = product.alive;
            pro.classificationId = product.classificationId;
            pro.companyId = product.companyId;
            pro.dosageFormsID = product.dosageFormsID;
            pro.englishName = product.englishName;
            pro.internationalCode = product.internationalCode;
            pro.isDeleted = product.isDeleted;
            pro.largeUnits = product.largeUnits;
            pro.largeUnitTypeID = product.largeUnitTypeID;
            pro.modifiedAt = DateTime.Now;
            pro.modifiedBy = product.modifiedBy;
            pro.price = product.price;
            pro.regitered = product.regitered;
            pro.regitrationNumberInMinistryOfHealth = product.regitrationNumberInMinistryOfHealth;
            pro.smallUnits = product.smallUnits;
            pro.smallUnitTypeID = product.smallUnitTypeID;
            pro.arabicName = product.arabicName;

            context.SaveChanges();

        }

        public async Task<List<Product>> Search(string filter)
        {
            var products = context.Products.Where(x => !(x.isDeleted));
            
                products = products.Where(x => (x.englishName.Contains(filter)) || (x.arabicName.Contains(filter)) || (x.internationalCode == filter));
            
                return await products.ToListAsync();
            
            
        }

        

    }
}
