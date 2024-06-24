using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBankingSystem.Entities.Request
{
    public class TownshipRequestDTO
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string StateCode { get; set; }
    }

    public class TownshipUpdateRequestDTO
    {
        public string Name { get; set; }
        public string StateCode { get; set; }
    }
}
