using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MiniBankingSystem.Entities.Request
{
    public class BankActionRequest
    {
        public decimal Amount { get; set; }
        public string AccountNo { get; set; }
    }
}
