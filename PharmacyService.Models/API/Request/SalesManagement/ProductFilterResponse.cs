using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.API.Request.SalesManagement
{
    public class ProductFilterResponse
    {
        public string name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }
        public int code { get; set; }
        [DataType(DataType.Date)]
        public DateTime expiry { get; set; }
        public int items { get; set; }
        public int defualtItems { get; set; }
    }
}
