using MiniBankingSystem.Constants.Exceptions;

namespace MiniBankingSystem.DataAccess.Services.TransactionHistory
{
    public class TransactionHistoryDataAccess
    {
        private readonly AppDbContext _context;

        public TransactionHistoryDataAccess(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TblTransactionHistory>> GetAllTransactionHistoriesAsync()
        {
            var transactionHistories = await _context.TblTransactionHistories.AsNoTracking().ToListAsync();
            return transactionHistories;
        }

        public async Task<TblTransactionHistory?> GetTransactionHistoryById(int transactionId)
        {
            var transactionHistory = await _context.TblTransactionHistories.AsNoTracking().FirstOrDefaultAsync(th => th.TransactionHistoryId == transactionId);
            return transactionHistory;
        }

        public async Task CreateTransaction(TblTransactionHistory tblTransactionHistory)
        {
            await _context.TblTransactionHistories.AddAsync(tblTransactionHistory);
            int result = await _context.SaveChangesAsync();
            if (result < 1)
            {
                throw new DBModifyException("Transaction Create Fail");
            }
        }

        public async Task UpdateTransaction(int transactionId, TblTransactionHistory requestTransactionHistory)
        {
            var existingTransactionHistory = await GetTransactionHistoryById(transactionId)
                                            ?? throw new NotFoundException("Transaction Not Found");

            existingTransactionHistory.Amount = requestTransactionHistory.Amount;
            existingTransactionHistory.TransactionType = requestTransactionHistory.TransactionType;
            existingTransactionHistory.FromAccountNo = requestTransactionHistory.FromAccountNo;
            existingTransactionHistory.ToAccountNo = requestTransactionHistory.ToAccountNo;

            _context.Entry(existingTransactionHistory).State = EntityState.Modified;
            _context.TblTransactionHistories.Update(existingTransactionHistory);
            int result = await _context.SaveChangesAsync();
            if (result < 1)
            {
                throw new DBModifyException("Transaction Update Fail");
            }
        }

        public async Task DeleteTransaction(int transactionId)
        {
            var existingTransactionHistory = await GetTransactionHistoryById(transactionId) 
                                            ?? throw new NotFoundException("Transaction Not Found");

            _context.Entry(existingTransactionHistory).State = EntityState.Deleted;
            _context.TblTransactionHistories.Remove(existingTransactionHistory);
            int result = await _context.SaveChangesAsync();
            if (result < 1)
            {
                throw new DBModifyException("Transaction Delete Fail");
            }
        }
    }
}
