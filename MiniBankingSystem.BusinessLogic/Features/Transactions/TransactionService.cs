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
            foreach (var tblTransactionHistory in tblTransactionHistories)
            {
                responseTransactions.Add(tblTransactionHistory.ChangeToResponseDTO());
            }
            return responseTransactions;
        }

        private async Task<PaginatedApiResponse> GetPaginatedTransactionHistories(int currentPageNo = 1, int itemPerPage = 10)
        {
            var paginatedTblTransactions = await _transactionDA.GetPaginatedTransactionHistoriesAsync(currentPageNo, itemPerPage);
            List<TransactionResponseDTO> responseTransactions = new();
            foreach (var tblTransactionHistory in paginatedTblTransactions.Data)
            {
                responseTransactions.Add(tblTransactionHistory.ChangeToResponseDTO());
            }
            var paginatedApiResponse = new PaginatedApiResponse()
            {
                currentPageNo = currentPageNo,
                itemsPerPage = itemPerPage,
                paginatedData = responseTransactions,
                totalPages = paginatedTblTransactions.TotalPages,
            };
            return paginatedApiResponse;
        }

        public async Task<TransactionResponseDTO> GetTransactionById(int transactionId)
        {
            var tblTransactionHistory = await _transactionDA.GetTransactionHistoryByIdAsync(transactionId);
            return tblTransactionHistory.ChangeToResponseDTO();
        }

        public async Task<TransactionRequestDTO> CreateTransaction(TransactionRequestDTO transactionRequest)
        {
            var tblTransaction = transactionRequest.ChangeToTbl();
            await _transactionDA.CreateTransactionAsync(tblTransaction);
            return transactionRequest;
        }

        public async Task<TransactionRequestDTO> UpdateTransaction(int transactionId, TransactionRequestDTO transactionRequest)
        {
            var tblTransaction = transactionRequest.ChangeToTbl();
            await _transactionDA.UpdateTransactionAsync(transactionId, tblTransaction);
            return transactionRequest;
        }

        public async Task DeleteTransaction(int transactionId)
        {
            await _transactionDA.DeleteTransactionAsync(transactionId);
        }
    }
}
