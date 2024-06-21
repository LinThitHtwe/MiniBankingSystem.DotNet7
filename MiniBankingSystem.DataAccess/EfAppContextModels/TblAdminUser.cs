using System;
using System.Collections.Generic;

namespace MiniBankingSystem.DataAccess.EfAppContextModels;

public partial class TblAdminUser
{
    public int AdminUserId { get; set; }

    public string AdminUserCode { get; set; } = null!;

    public string AdminUserName { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public string UserRoleCode { get; set; } = null!;
}
