using MiniBankingSystem.DataAccess.Services.Township;

namespace MiniBankingSystem.BusinessLogic.Features.Township
{
    public class TownshipService
    {
        private readonly TownshipDataAccess _townshipDA;

        public TownshipService(TownshipDataAccess townshipDA)
        {
            _townshipDA = townshipDA;
        }

        public async Task<List<TownshipResponseDTO>> GetAllTownships()
        {
            var tblPlaceTownships = await _townshipDA.GetAllTownshipsAsync();
            List<TownshipResponseDTO> responseTownships = new();
            foreach(var township in tblPlaceTownships)
            {
                responseTownships.Add(TownshipMapper.ChangeToResponseDTO(township)!);
            }
            return responseTownships;
        }

        public async Task<TownshipResponseDTO?> GetTownshipByCode(string townshipCode)
        {
            var tblPlaceTownship = await _townshipDA.GetTownshipByCodeAsync(townshipCode);
            var responseTownship = TownshipMapper.ChangeToResponseDTO(tblPlaceTownship);
            return responseTownship;
        }

       
    }
}
