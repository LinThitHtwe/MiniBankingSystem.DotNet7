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
    public static class TownshipMapper
    {
        public static TownshipResponseDTO? ChangeToResponseDTO(this TblPlaceTownship tblPlaceTownship)
        {
            return tblPlaceTownship == null ? null : new TownshipResponseDTO()
            {
                Code = tblPlaceTownship.TownshipCode,
                Name = tblPlaceTownship.TownshipName,
                StateCode = tblPlaceTownship.StateCode,
            };
        }

        public static TblPlaceTownship? ChangeToTblTownship(this TownshipRequestDTO townshipRequest)
        {
            return townshipRequest == null ? null : new TblPlaceTownship()
            {
                TownshipCode = townshipRequest.Code,
                TownshipName = townshipRequest.Name,
                StateCode = townshipRequest.StateCode
            };
        }

        public static TblPlaceTownship? ChangeToTblTownship(this TownshipUpdateRequestDTO townshipRequest)
        {
            return townshipRequest == null ? null : new TblPlaceTownship()
            {
                TownshipName = townshipRequest.Name,
                StateCode = townshipRequest.StateCode
            };
        }
    }
}
