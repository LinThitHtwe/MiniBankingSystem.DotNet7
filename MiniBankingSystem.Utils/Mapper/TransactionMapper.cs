using MiniBankingSystem.DataAccess.EfAppContextModels;
using MiniBankingSystem.Entities.Request;
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

        public static TblTransactionHistory? ChangeToTbl(this TransactionRequestDTO transactionRequest)
        {
            return transactionRequest is null ? null : new TblTransactionHistory()
            {
                AdminUserCode = transactionRequest.AdminUserCode,
                Amount = transactionRequest.Amount,
                FromAccountNo = transactionRequest.FromAccountNo,
                ToAccountNo = transactionRequest.ToAccountNo,
                TransactionDate = transactionRequest.TransactionDate,
                TransactionType = transactionRequest.TransactionType
            };
        }
    }
}
