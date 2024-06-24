using MiniBankingSystem.DataAccess.EfAppContextModels;
using MiniBankingSystem.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Utils.Mapper
{
    public class TownshipMapper
    {
        public static TownshipResponseDTO? ChangeToResponseDTO(TblPlaceTownship tblPlaceTownship)
        {
            return tblPlaceTownship == null ? null : new TownshipResponseDTO()
            {
                Code = tblPlaceTownship.TownshipCode,
                Name = tblPlaceTownship.TownshipName,
                StateCode = tblPlaceTownship.StateCode,
            };
        }
    }
}
