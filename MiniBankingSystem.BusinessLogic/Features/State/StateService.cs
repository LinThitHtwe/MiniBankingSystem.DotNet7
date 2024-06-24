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
                responseStates.Add(StateMapper.ChangeToResponseDTO(tblState)!);
            }
            return responseStates;
        }

        public async Task<StateResponseDTO?> GetStateByStateCode(string stateCode)
        {
            var tblState = await _stateDA.GetStateByStateCodeAsync(stateCode);
            var responseState = StateMapper.ChangeToResponseDTO(tblState);
            return responseState;
        }

        public async Task<StateRequestDTO> CreateState(StateRequestDTO requestState)
        {
            var tblState = StateMapper.ChangeToTblState(requestState);
            await _stateDA.CreateStateAsync(tblState);
            return requestState;
        }

        public async Task<StateRequestDTO> UpdateState(string stateCode, StateUpdateRequestDTO requestState)
        {
            var tblState = StateMapper.ChangeToTblState(requestState);
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
