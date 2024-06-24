﻿using MiniBankingSystem.DataAccess.Services.State;
using MiniBankingSystem.Entities.Request;
using MiniBankingSystem.Entities.Response;
using MiniBankingSystem.Utils.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<StateResponseDTO>  responseStates = new ();
            foreach(var tblState in tblStates)
            {
                responseStates.Add(StateMapper.ChangeToResponseDTO(tblState));
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

    }
}
