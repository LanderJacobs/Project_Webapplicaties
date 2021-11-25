using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class Bonus
    {
        public int BonusID { get; set; }
        public string Explanation { get; set; }

        public ICollection<Gear_Bonus> Gear_Bonussen { get; set; }
    }
}
