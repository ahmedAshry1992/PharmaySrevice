using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class Invoice: Defaults
    {
        public int userId { get; set; }
        public int? customerId { get; set; }
        //public bool isSaved { get; set; }
        public int statusId { get; set; }
        public int typeId { get; set; }
        public List<InvoiceDetails> MyProperty { get; set; }

    }
}
