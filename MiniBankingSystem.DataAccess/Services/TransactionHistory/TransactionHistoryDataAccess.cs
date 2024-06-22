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

        //public async Task<int> CreateTransaction
    }
}
