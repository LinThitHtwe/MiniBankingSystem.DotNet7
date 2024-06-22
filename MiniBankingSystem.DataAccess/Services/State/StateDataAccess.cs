﻿namespace MiniBankingSystem.DataAccess.Services.State
{
    public class StateDataAccess
    {
        private readonly AppDbContext _context;

        public StateDataAccess(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TblPlaceState>> GetAllStatesAsync()
        {
            var states = await _context.TblPlaceStates.AsNoTracking().ToListAsync();
            return states;
        }

        public async Task<TblPlaceState?> GetStateByStateCodeAsync(string stateCode)
        {
            var state = await _context.TblPlaceStates.AsNoTracking()
                                                     .FirstOrDefaultAsync(state=> state.StateCode == stateCode);
            return state;
        }

        public async Task<int> CreateStateAsync(TblPlaceState state)
        {
            await _context.TblPlaceStates.AddAsync(state);
            var result = await  _context.SaveChangesAsync();
            return result;
        }

        public async Task<int> UpdateStateAysnc(string stateCode, TblPlaceState requestState)
        {
            var existingState = await GetStateByStateCodeAsync(stateCode) ?? throw new Exception("");
            existingState.StateName = requestState.StateName;
            _context.Entry(existingState).State = EntityState.Modified;
            _context.TblPlaceStates.Update(existingState);

            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async  Task<int> DeleteStateAsync(string stateCode)
        {
            var existingState = await GetStateByStateCodeAsync(stateCode) ?? throw new Exception("");
            _context.Entry(existingState).State = EntityState.Deleted;
            _context.TblPlaceStates.Remove(existingState);

            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}