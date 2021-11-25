using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Models
{
    public class Gear
    {
        public int GearID { get; set; }
        public string Name { get; set; }
        public int? Tier { get; set; }
        public int? BaseAttack { get; set; }
        public int? BaseHealth { get; set; }
        public int? BaseSpeed { get; set; }
        public string? SpecAccPetBonus { get; set; }
        public int GeartypeID { get; set; }
        public int RankID { get; set; }
        public int ElementID { get; set; }
        public int BaseStatTotalID { get; set; }

        public Geartype Geartype { get; set; }
        public Rank Rank { get; set; }
        public Element Element { get; set; }
        public BaseStatTotal BaseStatTotal { get; set; }
    }
}
