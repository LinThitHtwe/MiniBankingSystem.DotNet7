using MiniBankingSystem.DataAccess.EfAppContextModels;
using MiniBankingSystem.Entities.Request;
using MiniBankingSystem.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Utils.Mapper
{
    public static class StateMapper
    {
        public static StateResponseDTO? ChangeToResponseDTO(this TblPlaceState tblPlaceState)
        {
            return tblPlaceState == null ? null : new StateResponseDTO
            {
                Code = tblPlaceState.StateCode,
                Name = tblPlaceState.StateName
            };
        }

        public static TblPlaceState ChangeToTblState(this StateRequestDTO stateRequestDTO)
        {
            return new TblPlaceState()
            {
                StateCode = stateRequestDTO.Code,
                StateName = stateRequestDTO.Name,
            };
        }

        public static TblPlaceState ChangeToTblState(this StateUpdateRequestDTO stateUpdateRequest)
        {
            return new TblPlaceState()
            {
                StateName = stateUpdateRequest.Name,
            };
        }
    }
}
