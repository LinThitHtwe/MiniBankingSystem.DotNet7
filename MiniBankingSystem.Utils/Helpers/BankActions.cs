using MiniBankingSystem.Constants.Exceptions;
using MiniBankingSystem.DataAccess.EfAppContextModels;
using MiniBankingSystem.DataAccess.Services.Account;
using MiniBankingSystem.Entities.Request;
using MiniBankingSystem.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Utils.Helpers
{
    public class BankActions
    {
        private readonly AccountDataAccess _accountDataAccess;

        public BankActions(AccountDataAccess accountDataAccess)
        {
            _accountDataAccess = accountDataAccess;
        }

        public async Task<BankActionResponse> Deposit(BankActionRequest request)
        {
            if (request.Amount < 1000)
            {
                throw new InvalidBankActionAmountException("Deposit Amount cannot be less then 1000");
            }

            BankActionResponse bankActionResponse = new()
            {
                accountNo = request.AccountNo,
                actionType = "Deposit",
                inputAmount = request.Amount,
            };

            var account = await IsAccountExist(request.AccountNo) ?? throw new InvalidAccountException("Account Id might be wrong or doesn't exist");

            bankActionResponse.previousBalance = account.Balance;
            account.Balance += request.Amount;

            await _accountDataAccess.UpdateAsync(request.AccountNo, account);

            bankActionResponse.newBalance = account.Balance;
            bankActionResponse.accountName = account.CustomerName;
            bankActionResponse.time = DateTime.Now;

            return bankActionResponse;
        }

        public async Task<BankActionResponse> Withdraw(BankActionRequest request)
        {
            if (request.Amount < 1000)
            {
                throw new InvalidBankActionAmountException("Withdraw Amount cannot be less then 1000");
            }

            BankActionResponse bankActionResponse = new()
            {
                accountNo = request.AccountNo,
                actionType = "Withdraw",
                inputAmount = request.Amount,
            };

            var account = await IsAccountExist(request.AccountNo) ?? throw new InvalidAccountException("Account Id might be wrong or doesn't exist");

            bankActionResponse.previousBalance = account.Balance;

            ValidateWithdrawalAmount(account.Balance, request.Amount);

            account.Balance -= request.Amount;

            await _accountDataAccess.UpdateAsync(request.AccountNo, account);

            bankActionResponse.newBalance = account.Balance;
            bankActionResponse.accountName = account.CustomerName;
            bankActionResponse.time = DateTime.Now;

            return bankActionResponse;
        }

        private async Task<TblAccount?> IsAccountExist(string accountNo)
        {
            var existingAccount = await _accountDataAccess.GetAccountByAccountNoAsync(accountNo);
            return existingAccount;
        }

        private void ValidateWithdrawalAmount(decimal balance, decimal amount)
        {
            if (balance < amount)
            {
                throw new InvalidBankActionAmountException("Withdraw cannot be larger than balance");
            }

            if (balance - amount < 1000)
            {
                throw new InvalidBankActionAmountException("At least 1000 should be left in account balance");
            }
        }
    }
}
