using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class Product: Defaults
    {
        public string englishName { set; get; }
        public string arabicName { set; get; }
        public string internationalCode { set; get; }        
        public string regitrationNumberInMinistryOfHealth { set; get; }
        public bool regitered { set; get; }
        public bool alive { set; get; }
        public int classificationId { set; get; }
        public int dosageFormsID { set; get; }
        public int largeUnitTypeID { set; get; }
        public int smallUnitTypeID { set; get; }
        public byte largeUnits { set; get; }
        public byte smallUnits { set; get; }
        public int? productsCompanyId { set; get; }
        [ForeignKey(nameof(productsCompanyId))]
        public ProductsCompany productsCompany { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { set; get; }
        public List<ProductToSell> productsToSell { get; set; }
        public List<ProductInPranche> productsInPranche { get; set; }
    }
}
