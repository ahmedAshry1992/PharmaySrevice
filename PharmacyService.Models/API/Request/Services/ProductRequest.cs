using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.API.Request.Services
{
    public class ProductRequest
    {
        public int id { get; set; }
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
        public int productsCompanyId { set; get; }
        public float price { set; get; }
        public bool isDeleted { get; set; }
        public ProductRequest()
        {
            this.isDeleted = false;
        }
    }
}
