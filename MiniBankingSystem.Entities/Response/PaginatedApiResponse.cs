using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Entities.Response
{
    public class PaginatedApiResponse
    {
        public int currentPageNo { get; set; }
        public int totalPages { get; set; }
        public int itemsPerPage {  get; set; }
        public object paginatedData { get; set; }
    }
}
