using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Entities.Response
{
    public class AccountResponseDTO
    {
        public string? AccountNo { get; set; }

        public string CustomerCode { get; set; }

        public decimal Balance { get; set; }

        public string? CustomerName { get; set; }
    }
}
