using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyService.Models.Domain
{
    public class Shift : Defaults
    {
        public int userId { get; set; }
        public decimal value { get; set; }
        public decimal receivedMoney { get; set; }
        public decimal extraditedMomey { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

    }
}
