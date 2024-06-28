using MiniBankingSystem.DataAccess.EfAppContextModels;
using MiniBankingSystem.DataAccess.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.BusinessLogic.Features.Account
{
    public class AccountService
    {
        private readonly AccountDataAccess _accountDA;

        public AccountService(AccountDataAccess accountDA)
        {
            _accountDA = accountDA;
        }

        public async Task<List<AccountResponseDTO>> GetAllAccounts()
        {
            var tblAccounts = await _accountDA.GetAllAccounts();
            List<AccountResponseDTO> responseAccounts = new();
            foreach (var tblAccount in tblAccounts)
            {
                responseAccounts.Add(tblAccount.ChangeToResponseDTO());
            }
            return responseAccounts;
        }

        public async Task<PaginatedApiResponse> GetPaginatedAccounts(int currentPageNo = 1, int itemPerPage = 10)
        {
            var paginatedTblAccouunts = await _accountDA.GetPaginatedAccountsAsync(currentPageNo, itemPerPage);
            List<AccountResponseDTO> responseAccounts = new();
            foreach (var tblAccount in paginatedTblAccouunts.Data)
            {
                responseAccounts.Add(tblAccount.ChangeToResponseDTO());
            }
            var paginatedApiResponse = new PaginatedApiResponse()
            {
                currentPageNo = currentPageNo,
                itemsPerPage = itemPerPage,
                paginatedData = responseAccounts,
                totalPages = paginatedTblAccouunts.TotalPages,
            };
            return paginatedApiResponse;
        }

        public async Task<AccountResponseDTO> GetAccountByAccountNo(string accountNo)
        {
            var tblAccount = await _accountDA.GetAccountByAccountNoAsync(accountNo);
            var responseAccount = AccountMapper.ChangeToResponseDTO(tblAccount);
            return responseAccount;
        }

        public async Task DeleteAccount(string accountNo)
        {
            await _accountDA.DeleteAsync(accountNo);
        }
    }
}
