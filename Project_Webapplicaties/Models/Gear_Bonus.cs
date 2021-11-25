using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class Gear_Bonus
    {
        public int Gear_BonusID { get; set; }
        public int GearID { get; set; }
        public int BonusID { get; set; }

        public Bonus Bonus { get; set; }
        public Gear Gear { get; set; }
    }
}
