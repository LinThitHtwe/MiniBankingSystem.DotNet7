using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Entities.Response
{
    public class PaginatedTblResponse<T>
    {
        public T Data { get; set; }
        public int TotalPages { get; set; }
    }
}

