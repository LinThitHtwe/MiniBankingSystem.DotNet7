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
            foreach(var tblAccount in tblAccounts)
            {
                responseAccounts.Add(AccountMapper.ChangeToResponseDTO(tblAccount));
            }
            return responseAccounts;
        }

        public async Task<AccountResponseDTO> GetAccountByAccountNo(string accountNo)
        {
            var tblAccount = await _accountDA.GetAccountByAccountNoAsync(accountNo);
            var responseAccount = AccountMapper.ChangeToResponseDTO(tblAccount);
            return responseAccount;
        }
    }
}
