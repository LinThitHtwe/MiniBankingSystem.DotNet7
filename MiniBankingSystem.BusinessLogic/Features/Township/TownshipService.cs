using MiniBankingSystem.Constants.Exceptions;
using MiniBankingSystem.DataAccess.EfAppContextModels;
using MiniBankingSystem.DataAccess.Services.State;
using MiniBankingSystem.DataAccess.Services.Township;

namespace MiniBankingSystem.BusinessLogic.Features.Township
{
    public class TownshipService
    {
        private readonly TownshipDataAccess _townshipDA;
        private readonly StateDataAccess _stateDA;

        public TownshipService(TownshipDataAccess townshipDA, StateDataAccess stateDA)
        {
            _townshipDA = townshipDA;
            _stateDA = stateDA;
        }

        public async Task<List<TownshipResponseDTO>> GetAllTownships()
        {
            var tblPlaceTownships = await _townshipDA.GetAllTownshipsAsync();
            List<TownshipResponseDTO> responseTownships = new();
            foreach (var township in tblPlaceTownships)
            {
                responseTownships.Add(TownshipMapper.ChangeToResponseDTO(township)!);
            }
            return responseTownships;
        }

        public async Task<List<TownshipResponseDTO>> GetTownshipsByStateCode(string stateCode)
        {
            var tblPlaceTownships = await _townshipDA.GetTownshipsByStateCodeAsync(stateCode);
            List<TownshipResponseDTO> responseTownships = new();
            foreach (var township in tblPlaceTownships)
            {
                responseTownships.Add(TownshipMapper.ChangeToResponseDTO(township)!);
            }
            return responseTownships;
        }

        public async Task<PaginatedApiResponse> GetPaginatedTownships(int currentPageNo = 1, int itemPerPage = 10)
        {
            var paginatedTblTownships = await _townshipDA.GetPaginatedTownshipsAsync(currentPageNo, itemPerPage);
            List<TownshipResponseDTO> responseTownships = new();
            foreach (var tblTownship in paginatedTblTownships.Data)
            {
                responseTownships.Add(TownshipMapper.ChangeToResponseDTO(tblTownship));
            }
            var paginatedApiResponse = new PaginatedApiResponse()
            {
                currentPageNo = currentPageNo,
                itemsPerPage = itemPerPage,
                paginatedData = responseTownships,
                totalPages = paginatedTblTownships.TotalPages,
            };
            return paginatedApiResponse;
        }

        public async Task<TownshipResponseDTO?> GetTownshipByCode(string townshipCode)
        {
            var tblPlaceTownship = await _townshipDA.GetTownshipByCodeAsync(townshipCode);
            var responseTownship = TownshipMapper.ChangeToResponseDTO(tblPlaceTownship);
            return responseTownship;
        }

        public async Task<TownshipRequestDTO> CreateTownship(TownshipRequestDTO requestTownship)
        {
            await CheckInvalidStateCode(requestTownship.StateCode);
            var tblTownship = TownshipMapper.ChangeToTblTownship(requestTownship);
            await _townshipDA.CreateAsync(tblTownship);
            return requestTownship;
        }

        public async Task<TownshipResponseDTO> UpdateTownship(string townshipCode, TownshipUpdateRequestDTO requestTownship)
        {
            await CheckInvalidStateCode(requestTownship.StateCode);
            var tblTownship = TownshipMapper.ChangeToTblTownship(requestTownship);
            await _townshipDA.UpdateAsync(townshipCode, tblTownship);
            TownshipResponseDTO responseTownship = new()
            {
                Code = townshipCode,
                Name = requestTownship.Name,
                StateCode = requestTownship.StateCode,
            };
            return responseTownship;
        }

        public async Task DeleteTownship(string townshipCode)
        {
            await _townshipDA.DeleteAsync(townshipCode);
        }

        private async Task CheckInvalidStateCode(string stateCode)
        {
            _ = await _stateDA.GetStateByStateCodeAsync(stateCode) ?? throw new NotFoundException("Invalid State Code");
        }
    }
}
