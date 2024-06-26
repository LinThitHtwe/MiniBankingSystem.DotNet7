using MiniBankingSystem.DataAccess.EfAppContextModels;
using MiniBankingSystem.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Utils.Mapper
{
    public static class TransactionMapper
    {
        public static TransactionResponseDTO? ChangeToResponseDTO(this TblTransactionHistory tblTransactionHistory)
        {
            return tblTransactionHistory is null ? null :
                                                 new TransactionResponseDTO()
                                                 {
                                                     AdminUserCode = tblTransactionHistory.AdminUserCode,
                                                     Amount = tblTransactionHistory.Amount,
                                                     FromAccountNo = tblTransactionHistory.FromAccountNo,
                                                     ToAccountNo = tblTransactionHistory.ToAccountNo,
                                                     TransactionDate = tblTransactionHistory.TransactionDate,
                                                     TransactionType = tblTransactionHistory.TransactionType
                                                 };
        }
    }
}
