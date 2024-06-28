using Azure;
using MiniBankingSystem.Constants.Exceptions;
using MiniBankingSystem.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.DataAccess.Services.Account
{
    public class AccountDataAccess
    {
        private AppDbContext _context;

        public AccountDataAccess(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TblAccount>> GetAllAccounts()
        {
            var accounts = await _context.TblAccounts.AsNoTracking().ToListAsync();
            return accounts;
        }

        public async Task<PaginatedTblResponse> GetPaginatedAccountsAsync(int currentPageNo, int itemPerPage = 10)
        {
            var paginatedAccounts = await _context.TblAccounts.AsNoTracking()
                                                              .Skip((currentPageNo - 1) * itemPerPage)
                                                              .Take(itemPerPage)
                                                              .ToListAsync();

            int rowCount = await _context.TblAccounts.CountAsync();
            int totalPages = (int)Math.Ceiling((double)rowCount / itemPerPage);

            var paginatedResponse = new PaginatedTblResponse()
            {
                Data = paginatedAccounts,
                TotalPages = totalPages,
            };

            return paginatedResponse;
        }

        public async Task<TblAccount?> GetAccountByAccountNoAsync(string accountNo)
        {
            var account = await _context.TblAccounts.AsNoTracking()
                                                    .FirstOrDefaultAsync(account => account.AccountNo == accountNo);
            return account;
        }

        public async Task<int> CreateAsync(TblAccount account)
        {
            await _context.TblAccounts.AddAsync(account);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task UpdateAsync(string accountNo, TblAccount requestAccount)
        {
            var existingAccount = await GetAccountByAccountNoAsync(accountNo) ?? throw new NotFoundException("Account Not Found");
            existingAccount.CustomerName = requestAccount.CustomerName;
            existingAccount.Balance = requestAccount.Balance;
            _context.Entry(existingAccount).State = EntityState.Modified;
            _context.TblAccounts.Update(existingAccount);
            var result = await _context.SaveChangesAsync();
            if (result < 1)
            {
                throw new DBModifyException("Account Delete Error");
            }

        }

        public async Task<int> DeleteAsync(string accountNo)
        {
            var existingAccount = await GetAccountByAccountNoAsync(accountNo) ?? throw new NotFoundException("Account Not Found");
            _context.Entry(existingAccount).State = EntityState.Deleted;
            _context.TblAccounts.Remove(existingAccount);
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
