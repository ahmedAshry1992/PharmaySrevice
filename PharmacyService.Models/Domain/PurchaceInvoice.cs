using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class PurchaceInvoice : Defaults
    {       
        public int? userId { get; set; }
        [ForeignKey(nameof(userId))]
        public User user { get; set; }
        public int prancheId { get; set; }
        [ForeignKey(nameof(prancheId))]
        public Pranche pranche { get; set; }
        public int companyId { get; set; }
        public int supplierId { get; set; }        
        public List<PurchaceInvoiceDetails> purchaceInvoiceDetails { get; set; }
    }
}
