using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class Invoice: Defaults
    {
        public int userId { get; set; }
        public int? customerId { get; set; }

    }
}
