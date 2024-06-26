using MiniBankingSystem.Constants.Exceptions;

namespace MiniBankingSystem.DataAccess.Services.Township
{
    public class TownshipDataAccess
    {
        private readonly AppDbContext _context;

        public TownshipDataAccess(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TblPlaceTownship>> GetAllTownshipsAsync()
        {
            var townships = await _context.TblPlaceTownships.AsNoTracking().ToListAsync();
            return townships;
        }

        public async Task<TblPlaceTownship?> GetTownshipByCodeAsync(string townshipCode)
        {
            var township = await _context.TblPlaceTownships.AsNoTracking()
                                                           .FirstOrDefaultAsync(township => township.TownshipCode == townshipCode);
            return township;
        }

        public async Task<TblPlaceTownship?> GetTownshipByStateCodeAsync(string stateCode)
        {
            var township = await _context.TblPlaceTownships.AsNoTracking()
                                                           .FirstOrDefaultAsync(township => township.StateCode == stateCode);
            return township;
        }

        public async Task CreateAsync(TblPlaceTownship township)
        {
            await _context.TblPlaceTownships.AddAsync(township);
            var result = await _context.SaveChangesAsync();
            if (result < 1)
            {
                throw new DBModifyException("Township Create Error");
            }
        }

        public async Task UpdateAsync(string townshipCode, TblPlaceTownship requestTownship)
        {
            var existingTownship = await GetTownshipByCodeAsync(townshipCode) ?? throw new NotFoundException("Township Not Found");
            existingTownship.TownshipName = requestTownship.TownshipName;
            existingTownship.StateCode = requestTownship.StateCode;
            _context.Entry(existingTownship).State = EntityState.Modified;
            _context.TblPlaceTownships.Update(existingTownship);

            var result = await _context.SaveChangesAsync();
            if (result < 1)
            {
                throw new DBModifyException("Township Update Error");
            }
        }

        public async Task DeleteAsync(string townshipCode)
        {
            var existingTownship = await GetTownshipByCodeAsync(townshipCode) ?? throw new NotFoundException("");
            _context.Entry(existingTownship).State = EntityState.Deleted;
            _context.TblPlaceTownships.Remove(existingTownship);

            var result = await _context.SaveChangesAsync();
            if (result < 1)
            {
                throw new DBModifyException("Township Delete Error");
            }
        }
    }
}
