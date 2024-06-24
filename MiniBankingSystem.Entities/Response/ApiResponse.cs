using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Entities.Response
{
    public class ApiResponse
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public object responseData { get; set; }
        public DateTime time { get; set; }
    }
}
