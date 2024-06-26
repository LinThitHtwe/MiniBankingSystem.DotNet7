using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Entities.Response
{
    public class BankActionResponse
    {
        public string accountNo { get; set; }
        public string accountName { get; set; }
        public decimal inputAmount { get; set; }
        public decimal previousBalance { get; set; }
        public decimal newBalance {  get; set; }
        public DateTime time {  get; set; }
        public string actionType {  get; set; }
    }
}
