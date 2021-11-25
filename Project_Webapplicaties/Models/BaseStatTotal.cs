using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class BaseStatTotal
    {
        public int BaseStatTotalID { get; set; }
        public int Base { get; set; }
        public int Upgrade1 { get; set; }
        public int? Upgrade2 { get; set; }
        public int? Upgrade3 { get; set; }
        public int? Upgrade4 { get; set; }

        public ICollection<Gear> Gears { get; set; }
    }
}
