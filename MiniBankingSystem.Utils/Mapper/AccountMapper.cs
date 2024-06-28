using MiniBankingSystem.DataAccess.EfAppContextModels;
using MiniBankingSystem.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Utils.Mapper
{
    public static class AccountMapper
    {
        public static AccountResponseDTO? ChangeToResponseDTO(this TblAccount? tblAccount)
        {
            return tblAccount == null ? null : new AccountResponseDTO()
            {
                AccountNo = tblAccount.AccountNo,
                Balance = tblAccount.Balance,
                CustomerCode = tblAccount.CustomerCode,
                CustomerName = tblAccount.CustomerName
            };
        }
    }
}
