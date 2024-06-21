using System;
using System.Collections.Generic;

namespace MiniBankingSystem.DataAccess.EfAppContextModels;

public partial class TblAccount
{
    public int AccountId { get; set; }

    public string? AccountNo { get; set; }

    public string CustomerCode { get; set; } = null!;

    public decimal Balance { get; set; }

    public string? CustomerName { get; set; }
}
