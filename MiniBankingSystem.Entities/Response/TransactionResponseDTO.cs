using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Entities.Response
{
    public class TransactionResponseDTO
    {
        public string FromAccountNo { get; set; } = null!;
        public string ToAccountNo { get; set; } = null!;
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string AdminUserCode { get; set; }
        public string TransactionType { get; set; } = null!;
    }
}
