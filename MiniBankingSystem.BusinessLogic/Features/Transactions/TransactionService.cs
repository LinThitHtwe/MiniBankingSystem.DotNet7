using MiniBankingSystem.DataAccess.Services.TransactionHistory;
using MiniBankingSystem.Utils.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.BusinessLogic.Features.Transactions
{
    public class TransactionService
    {
        private readonly TransactionHistoryDataAccess _transactionDA;

        public TransactionService(TransactionHistoryDataAccess transactionDA)
        {
            _transactionDA = transactionDA;
        }

        public async Task<List<TransactionResponseDTO>> GetAllTransactionHistories()
        {
            var tblTransactionHistories = await _transactionDA.GetAllTransactionHistoriesAsync();
            List<TransactionResponseDTO> responseTransactions = new();
            foreach(var tblTransactionHistory in tblTransactionHistories)
            {
                responseTransactions.Add(tblTransactionHistory.ChangeToResponseDTO());
            }
            return responseTransactions;
        }

        public async Task<TransactionResponseDTO> GetTransactionById(int transactionId)
        {
            var tblTransactionHistory = await _transactionDA.GetTransactionHistoryByIdAsync(transactionId);
            return tblTransactionHistory.ChangeToResponseDTO();
        }

        public async Task DeleteTransaction(int transactionId)
        {
            await _transactionDA.DeleteTransactionAsync(transactionId);
        }
    }
}
