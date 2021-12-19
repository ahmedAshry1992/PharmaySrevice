using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class Shift : Defaults
    {
        public int prancheId { get; set; }
        [ForeignKey(nameof(prancheId))]
        public Pranche pranche { get; set; }
        public int companyId { get; set; }        
        public int? userId { get; set; }
        [ForeignKey(nameof(userId))]
        public User user { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal value { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal receivedMoney { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal extraditedMomey { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

    }
}
