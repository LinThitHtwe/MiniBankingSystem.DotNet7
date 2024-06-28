using MiniBankingSystem.DataAccess.Services.State;

namespace MiniBankingSystem.BusinessLogic.Features.State
{
    public class StateService
    {
        private readonly StateDataAccess _stateDA;

        public StateService(StateDataAccess stateDA)
        {
            _stateDA = stateDA;
        }
        public async Task<List<StateResponseDTO>> GetAllStates()
        {
            var tblStates = await _stateDA.GetAllStatesAsync();
            List<StateResponseDTO> responseStates = new();
            foreach (var tblState in tblStates)
            {
                responseStates.Add(tblState.ChangeToResponseDTO()!);
            }
            return responseStates;
        }

        public async Task<PaginatedApiResponse> GetPaginatedStates(int currentPageNo = 1, int itemPerPage = 10)
        {
            var paginatedTblStates = await _stateDA.GetPaginatedStateAsync(currentPageNo, itemPerPage);
            List<StateResponseDTO> responseStates = new();
            foreach (var tblState in paginatedTblStates.Data)
            {
                responseStates.Add(tblState.ChangeToResponseDTO()!);
            }
            var paginatedApiResponse = new PaginatedApiResponse()
            {
                currentPageNo = currentPageNo,
                itemsPerPage = itemPerPage,
                paginatedData = responseStates,
                totalPages = paginatedTblStates.TotalPages,
            };
            return paginatedApiResponse;
        }

        public async Task<StateResponseDTO?> GetStateByStateCode(string stateCode)
        {
            var tblState = await _stateDA.GetStateByStateCodeAsync(stateCode);
            var responseState = tblState.ChangeToResponseDTO();
            return responseState;
        }

        public async Task<StateRequestDTO> CreateState(StateRequestDTO requestState)
        {
            var tblState = requestState.ChangeToTblState();
            await _stateDA.CreateStateAsync(tblState);
            return requestState;
        }

        public async Task<StateRequestDTO> UpdateState(string stateCode, StateUpdateRequestDTO requestState)
        {
            var tblState = requestState.ChangeToTblState();
            await _stateDA.UpdateStateAysnc(stateCode, tblState);
            StateRequestDTO updatedState = new()
            {
                Code = stateCode,
                Name = requestState.Name
            };
            return updatedState;
        }

        public async Task DeleteState(string stateCode)
        {
            await _stateDA.DeleteStateAsync(stateCode);
        }
    }
}
